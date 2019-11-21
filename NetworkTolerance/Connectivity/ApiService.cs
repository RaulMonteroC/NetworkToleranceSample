using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fusillade;
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

        public ApiService()
        {
            _policyBuilder = new PolicyBuilder();
        }

        public async Task Call(Func<TApi, Task> apiCall, CallPriority priority)
        {
            var apiDefinition = LoadApiDefinition(priority);
            await _policyBuilder.Build().ExecuteAsync(async () => await apiCall(apiDefinition));
        }
        
        public async Task<TResult> Call<TResult>(Func<TApi, Task<TResult>> apiCall, CallPriority priority)
        {
            var apiDefinition = LoadApiDefinition(priority);
            return await _policyBuilder.Build<TResult>().ExecuteAsync(async () => await apiCall(apiDefinition));
        }
        
        private TApi LoadApiDefinition(CallPriority priority)
        {
            var client = new HttpClient(new RateLimitedHttpMessageHandler(new LoggedHttpClientHandler(),priority.ToFusilladePriority()))
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
    }
}
