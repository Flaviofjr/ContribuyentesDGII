

namespace ContribuyentesDGII.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyentesController : ControllerBase
    {
        private readonly IContribuyenteService _contribuyenteService;
        private readonly ILogger<ContribuyentesController> _logger;
        public ContribuyentesController(IContribuyenteService contribuyenteService, ILogger<ContribuyentesController> logger)
        {
            _contribuyenteService = contribuyenteService;
            _logger = logger;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var RncCedulaExists = _contribuyenteService.RncCedulaExists(contribuyente.RncCedula);
                if (RncCedulaExists)
                {
                    ModelState.AddModelError(nameof(contribuyente.RncCedula), "El número de RNC/CEDULA ingresado ya existe.");
                    return BadRequest(ModelState);
                }
                var createdEntity = await _contribuyenteService.AddContribuyente(contribuyente);
                return CreatedAtAction("GetById", new { id = createdEntity.RncCedula }, createdEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurrido mientras se creaba un contribuyente.");
                return StatusCode(500, "Un error ha ocurrido mientras se creaba el contribuyente. Por favor inténtelo mas tarde.");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Contribuyente>> Update(string id, Contribuyente contribuyente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (id != contribuyente.RncCedula)
                {
                    ModelState.AddModelError(nameof(contribuyente.RncCedula), "El numero de RNC/CÉDULA no puede ser modificado.");
                    return BadRequest(ModelState);
                }
                var updatedContribuyente = await _contribuyenteService.UpdateContribuyente(id, contribuyente);
                if (updatedContribuyente == null)
                {
                    _logger.LogWarning($"Contribuyente con RNC/CEDULA {id} no encontrado");
                    return NotFound();
                }
                return Ok(updatedContribuyente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurrido mientras se actualizaba un contribuyente.");
                return StatusCode(500, "Un error ha ocurrido mientras se actualizaban los datos del contribuyente. Por favor inténtelo mas tarde.");
            }
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
