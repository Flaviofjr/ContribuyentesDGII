using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContribuyentesDGII.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobantesFiscalesController : ControllerBase
    {
        private readonly IComprobanteFiscalService _comprobanteFiscalService;
        private readonly IContribuyenteService _contribuyenteService;
        private readonly ILogger<ComprobantesFiscalesController> _logger;
        private readonly IMapper _mapper;
        public ComprobantesFiscalesController(IComprobanteFiscalService comprobanteFiscalService, 
            IContribuyenteService contribuyenteService, ILogger<ComprobantesFiscalesController> logger,
            IMapper mapper)
        {
            _comprobanteFiscalService = comprobanteFiscalService;
            _contribuyenteService = contribuyenteService;
            _logger = logger;
            _mapper = mapper;
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
                _logger.LogWarning($"El comprobante con NCF: {id} no fue encontrado");
                return NotFound();
            }
            return Ok(comprobante);
        }
        [HttpPost]
        public async Task<ActionResult<ComprobanteFiscal>> Create(ComprobanteDTO comprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (comprobante.Monto <= 0)
                {
                    ModelState.AddModelError(nameof(comprobante.Monto), "El monto debe ser mayor que cero.");
                    return BadRequest(ModelState);
                }
                //Validar que la cedula exista
                var rncCedulaExists = _contribuyenteService.RncCedulaExists(comprobante.RncCedula);
                if (!rncCedulaExists)
                {
                    ModelState.AddModelError(nameof(comprobante.RncCedula), "RNC/CEDULA no esta dentro de los contribuyentes agregados.");
                    return BadRequest(ModelState);
                }
                // Validar que NCF sea unico
                var NcfExists = _comprobanteFiscalService.NcfExists(comprobante.NCF);
                if (NcfExists)
                {
                    ModelState.AddModelError(nameof(comprobante.NCF), "El NCF ingresado ya existe.");
                    return BadRequest(ModelState);
                }
                
                var createdEntity = await _comprobanteFiscalService.AddComprobante(_mapper.Map<ComprobanteDTO, ComprobanteFiscal>(comprobante));
                return CreatedAtAction("GetById", new { id = createdEntity.RncCedula }, createdEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurrido mientras se creaba un comprobante fiscal.");
                return StatusCode(500, "Un error ha ocurrido mientras se creaba el comprobante fiscal. Por favor inténtelo mas tarde.");
            }
            
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ComprobanteFiscal>> Update(string id, ComprobanteDTO comprobante)
        {
            try
            {
                if (id != comprobante.NCF)
                {
                    ModelState.AddModelError(nameof(comprobante.NCF), "El NCF no puede ser modificado.");
                    return BadRequest(ModelState);
                }
                if (comprobante.Monto <= 0)
                {
                    ModelState.AddModelError(nameof(comprobante.Monto), "El monto debe ser mayor que cero.");
                    return BadRequest(ModelState);
                }
                var updatedComprobante = await _comprobanteFiscalService.UpdateComprobante(id, _mapper.Map<ComprobanteDTO, ComprobanteFiscal>(comprobante));
                if (updatedComprobante == null)
                {
                    return NotFound();
                }
                return Ok(updatedComprobante);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurrido mientras se actualizaba un comprobante.");
                return StatusCode(500, "Un error ha ocurrido mientras se actualizaban los datos del comprobante. Por favor inténtelo mas tarde.");
            }
            
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
