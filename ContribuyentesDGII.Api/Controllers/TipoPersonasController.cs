using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContribuyentesDGII.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPersonasController : GenericController<TipoPersona>
    {
        public TipoPersonasController(IGenericService<TipoPersona> service, ILogger<GenericController<TipoPersona>> logger) : base(service, logger)
        {
        }
    }
}
