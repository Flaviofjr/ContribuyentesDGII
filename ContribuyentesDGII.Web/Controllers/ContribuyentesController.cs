


namespace ContribuyentesDGII.Web.Controllers
{
    public class ContribuyentesController : Controller
    {
        private readonly IClientApiService _clientApiService;
        public ContribuyentesController(IClientApiService clientApiService)
        {
            _clientApiService = clientApiService;
        }
        public async Task<IActionResult> Index()
        {
            List<ContribuyenteDTO>? contribuyentes = await _clientApiService.Get<List<ContribuyenteDTO>>("Contribuyentes");
            return View(contribuyentes);
        }

        public async Task<IActionResult> Details(string id)
        {
            Contribuyente? contribuyente = await _clientApiService.Get<Contribuyente>("Contribuyentes/" + id);
            return View(contribuyente);
        }
    }
}
