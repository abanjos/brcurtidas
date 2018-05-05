using BRCurtidas.Common;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BRCurtidas.PagSeguro
{
    public class PagSeguroClient
    {
        private readonly string _url;
        private readonly PagSeguroCredentials _credentials;

        public PagSeguroClient(string url, PagSeguroCredentials credentials)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            if (!url.IsValidUrl())
                throw new ArgumentException("Invalid service URL.");

            _url = url.TrimEnd('/');
            _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
        }

        public async Task<CheckoutResponse> CreateCheckout(CheckoutRequest request)
        {
            var requestXml = request.SerializeToXml(Encodings.Latin1);
            var requestUrl = $"{_url}/checkout?email={HttpUtility.UrlEncode(_credentials.Email)}&token={_credentials.Token}";

            using (var client = new HttpClient())
            {
                var requestContent = new StringContent(requestXml, Encodings.Latin1, MediaTypes.Xml);
                var result = await client.PostAsync(requestUrl, requestContent);

                var response = await result.Content.ReadAsStringAsync();

                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception($"Unsuccessful status code returned from PagSeguro API. {result.StatusCode}: {response}");
                }

                return response.XmlDeserialize<CheckoutResponse>();
            }
        }
    }
}
