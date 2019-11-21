using System;
using System.Net.Http;
using System.Threading.Tasks;
using NetworkTolerance.Connectivity.HTTPClients;
using NetworkTolerance.Connectivity.Policies;
using NetworkTolerance.Framework.Attributes;
using NetworkTolerance.Framework.Keys;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace NetworkTolerance.Connectivity
{
    public class ApiService<TApi> : IApiService<TApi>
    {
        private readonly PolicyBuilder _policyBuilder;
        private readonly TApi _api;

        public ApiService()
        {
            _policyBuilder = new PolicyBuilder();
            _api = LoadApi();
        }
        
        private TApi LoadApi()
        {
            var client = new HttpClient(new LoggedHttpClientHandler())
            {
                BaseAddress = new Uri(GetUrl())
            };

            var api = RestService.For<TApi>(client, new RefitSettings
            {
                ContentSerializer = new JsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            });

            return api;
        }
        
        private string GetUrl()
        {
            var urlAttribute = (UrlAttribute)Attribute.GetCustomAttribute(typeof(TApi), typeof(UrlAttribute));

            return urlAttribute.Url;
        }

        public async Task Call(Func<TApi, Task> apiCall)
        {
            await _policyBuilder.Build().ExecuteAsync(async () => await apiCall(_api));
        }
        
        public async Task<TResult> Call<TResult>(Func<TApi, Task<TResult>> apiCall)
        {
            return await _policyBuilder.Build<TResult>().ExecuteAsync(async () => await apiCall(_api));
        }
    }
}
