


namespace ContribuyentesDGII.Web.Controllers
{
    public class ContribuyentesController : Controller
    {
        private readonly HttpClient _httpClient;
        public ContribuyentesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IActionResult> Index()
        {
            List<ContribuyenteDTO>? contribuyentes = new();
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(InternalConnections.ApiBaseEndpoint + "Contribuyentes");
                string apiResponse = await response.Content.ReadAsStringAsync();
                contribuyentes = JsonConvert.DeserializeObject<List<ContribuyenteDTO>>(apiResponse);
            }
            return View(contribuyentes);
        }

        public async Task<IActionResult> Details(string id)
        {
            Contribuyente? contribuyente = new();
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(InternalConnections.ApiBaseEndpoint + "Contribuyentes/" + id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                contribuyente = JsonConvert.DeserializeObject<Contribuyente>(apiResponse);
            }
            return View(contribuyente);
        }
    }
}
