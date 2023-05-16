using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContribuyentesDGII.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatusController : GenericController<Estatus>
    {
        public EstatusController(IGenericService<Estatus> service) : base(service)
        {
        }
    }
}
