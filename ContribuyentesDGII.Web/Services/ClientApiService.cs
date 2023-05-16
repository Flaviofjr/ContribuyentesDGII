namespace ContribuyentesDGII.Web.Services
{
    public interface IClientApiService
    {
        Task<T> Get<T>(string reaminingUrl);
    }
    public class ClientApiService : IClientApiService
    {
        private readonly HttpClient _httpClient;
        public ClientApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        public async Task<T> Get<T>(string reaminingUrl)
        {
            using var response = await _httpClient.GetAsync(InternalConnections.ApiBaseEndpoint + reaminingUrl);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(apiResponse);
        }
    }
}
