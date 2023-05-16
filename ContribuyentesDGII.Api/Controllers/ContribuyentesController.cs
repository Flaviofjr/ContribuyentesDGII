using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContribuyentesDGII.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyentesController : ControllerBase
    {
        private readonly IContribuyenteService _contribuyenteService;
        public ContribuyentesController(IContribuyenteService contribuyenteService)
        {
            _contribuyenteService = contribuyenteService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContribuyenteDTO>>> GetAll()
        {
            var contribuyentes = await _contribuyenteService.GetContribuyentes();
            return Ok(contribuyentes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contribuyente>> GetById(string id)
        {
            var contribuyente = await _contribuyenteService.GetContribuyente(id);
            if (contribuyente == null)
            {
                return NotFound();
            }
            return Ok(contribuyente);
        }
        [HttpPost]
        public async Task<ActionResult<Contribuyente>> Create(Contribuyente contribuyente)
        {
            var createdEntity = await _contribuyenteService.AddContribuyente(contribuyente);
            return CreatedAtAction("GetById", new { id = createdEntity.RncCedula }, createdEntity);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Contribuyente>> Update(string id, Contribuyente contribuyente)
        {
            var updatedContribuyente = await _contribuyenteService.UpdateContribuyente(id, contribuyente);
            if (updatedContribuyente == null)
            {
                return NotFound();
            }
            return Ok(updatedContribuyente);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _contribuyenteService.DeleteContribuyente(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
