


namespace ContribuyentesDGII.Web.Controllers
{
    public class ContribuyentesController : Controller
    {
        private readonly HttpClient _httpClient;
        public ContribuyentesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(InternalConnections.ApiBaseEndpoint);
        }
        public async Task<IActionResult> Index()
        {
            List<ContribuyenteDTO>? contribuyentes = new();
            HttpResponseMessage response = await _httpClient.GetAsync("Contribuyentes");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                contribuyentes = JsonSerializer.Deserialize<List<ContribuyenteDTO>>(jsonResponse);
            }
            return View(contribuyentes);
        }
    }
}
