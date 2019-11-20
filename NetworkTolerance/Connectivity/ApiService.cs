using System;
using System.Net.Http;
using NetworkTolerance.Framework.Attributes;
using NetworkTolerance.Framework.Keys;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace NetworkTolerance.Connectivity
{
    public class ApiService<TApi> : IApiService<TApi>
    {
        public TApi Api { get; }

        public ApiService()
        {
            Api = LoadApi();
        }

        private TApi LoadApi()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(GetUrl()),
                Timeout = TimeSpan.FromSeconds(AppConstants.TimeoutSeconds)
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
