using System;
using System.Collections.Generic;
using BRCurtidas.Common;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace BRCurtidas.Web.UI.Services.ApiClient
{
    public class ApiClientService : IApiClientService
    {
        private readonly string _url;

        public ApiClientService(string url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            if (!url.IsValidUrl())
                throw new ArgumentException("Invalid service URL.");

            _url = url.TrimEnd('/');
        }

        private async Task<IEnumerable<ServiceType>> GetServiceTypes(int socialNetworkId)
        {
            var requestUrl = $"{_url}/api/services/types?socialnetwork={socialNetworkId}";

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(requestUrl);
                var response = await result.Content.ReadAsStringAsync();

                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception($"Unsuccessful status code returned from BRCurtidas API. {result.StatusCode}: {response}");
                }

                return response.JsonDeserialize<IEnumerable<ServiceType>>();
            }
        }

        public async Task<IEnumerable<SocialNetwork>> GetSocialNetworksAsync()
        {
            var requestUrl = $"{_url}/api/socialnetworks";

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(requestUrl);
                var response = await result.Content.ReadAsStringAsync();

                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception($"Unsuccessful status code returned from BRCurtidas API. {result.StatusCode}: {response}");
                }

                var socialNetworks = response.JsonDeserialize<IEnumerable<SocialNetwork>>();

                foreach (var socialNetwork in socialNetworks)
                {
                    var serviceTypes = await GetServiceTypes(socialNetwork.Id);
                    socialNetwork.ServiceTypes = serviceTypes.ToArray();
                }

                return socialNetworks;
            }
        }

        public async Task<ScopedServiceType> GetServiceWithProductsAsync(string slug)
        {
            var requestUrl = $"{_url}/api/scopedservicetypes?slug={slug}";

             using (var client = new HttpClient())
             {
                 var result = await client.GetAsync(requestUrl);
                 var response = await result.Content.ReadAsStringAsync();

                  if (!result.IsSuccessStatusCode)
                {
                    throw new Exception($"Unsuccessful status code returned from BRCurtidas API. {result.StatusCode}: {response}");
                }

                var scopedServiceType = response.JsonDeserialize<ScopedServiceType>();
                var result2 = await GetProductsAsync(scopedServiceType.Id);
                scopedServiceType.Products = result2.ToArray();

                return scopedServiceType;

             }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int id)
        {
            var requestUrl = $"{_url}/api/products?scopedservicetypeid={id}";

             using (var client = new HttpClient())
             {
                 var result = await client.GetAsync(requestUrl);
                 var response = await result.Content.ReadAsStringAsync();

                  if (!result.IsSuccessStatusCode)
                {
                    throw new Exception($"Unsuccessful status code returned from BRCurtidas API. {result.StatusCode}: {response}");
                }
                var products = response.JsonDeserialize<IEnumerable<Product>>();

                return products;
             }
        }
    }
}


