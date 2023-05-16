using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContribuyentesDGII.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobantesFiscalesController : GenericController<ComprobanteFiscal>
    {
        public ComprobantesFiscalesController(IGenericService<ComprobanteFiscal> service) : base(service)
        {
        }
    }
}
