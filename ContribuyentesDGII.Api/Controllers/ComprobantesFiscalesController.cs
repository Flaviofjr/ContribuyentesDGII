using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComprobantesDGII.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobantesFiscalesController : ControllerBase
    {
        private readonly IComprobanteFiscalService _comprobanteFiscalService;
        public ComprobantesFiscalesController(IComprobanteFiscalService comprobanteFiscalService)
        {
            _comprobanteFiscalService = comprobanteFiscalService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComprobanteFiscal>>> GetAll()
        {
            var comprobantes = await _comprobanteFiscalService.GetComprobantes();
            return Ok(comprobantes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComprobanteFiscal>> GetById(string id)
        {
            var comprobante = await _comprobanteFiscalService.GetComprobante(id);
            if (comprobante == null)
            {
                return NotFound();
            }
            return Ok(comprobante);
        }
        [HttpPost]
        public async Task<ActionResult<ComprobanteFiscal>> Create(ComprobanteFiscal comprobante)
        {
            var createdEntity = await _comprobanteFiscalService.AddComprobante(comprobante);
            return CreatedAtAction("GetById", new { id = createdEntity.RncCedula }, createdEntity);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ComprobanteFiscal>> Update(string id, ComprobanteFiscal comprobante)
        {
            var updatedComprobante = await _comprobanteFiscalService.UpdateComprobante(id, comprobante);
            if (updatedComprobante == null)
            {
                return NotFound();
            }
            return Ok(updatedComprobante);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _comprobanteFiscalService.DeleteComprobante(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
