using System.Net.Http.Headers;

namespace ContribuyentesDGII.Web.Services
{
    public interface IHttpCustomClientFactory
    {
        HttpClient CreateClient();
    }
    public class ClientHttpFactory : IHttpCustomClientFactory
    {
        public string? baseAddress = InternalConnections.ApiBaseEndpoint;
        public HttpClient CreateClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                //Configurar el certificado
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };
            // Pasar el handler a httpclient
            var client = new HttpClient(clientHandler);
            SetupClientDefaults(client);
            return client;
        }

        protected virtual void SetupClientDefaults(HttpClient client)
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
