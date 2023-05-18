using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContribuyentesDGII.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly IGenericService<T> _service;
        private readonly ILogger<GenericController<T>> _logger;
        public GenericController(IGenericService<T> service, ILogger<GenericController<T>> logger)
        {
            _service = service;
            _logger = logger;
        }
        // GET: api/<GenericController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            var entitiesList = await _service.GetAll();
            return Ok(entitiesList);
        }

        // GET api/<GenericController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetById(int id)
        {
            var entity = await _service.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST api/<GenericController>
        [HttpPost]
        public async Task<ActionResult<T>> Create(T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdEntity = await _service.Create(entity);
                return createdEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error ocurrido mientras se ingresaba un nuevo registro. {ex.Message}");
                return StatusCode(500, $"Un error ha ocurrido mientras se creaba un registro. {ex.Message}");
            }
        }


        // PUT api/<GenericController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Update(int id, T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedEntity = await _service.Update(id, entity);
                if (updatedEntity == null)
                {
                    return NotFound();
                }
                return Ok(updatedEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error ocurrido mientras se actualizaba registro. {ex.Message}");
                return StatusCode(500, $"Un error ha ocurrido mientras se actualizaba un registro. {ex.Message}");
            }
        }

        // DELETE api/<GenericController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.Delete(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error ocurrido mientras se eliminaba un registro. {ex.Message}");
                return StatusCode(500, $"Un error ha ocurrido mientras se eliminaba un registro. {ex.Message}");
            }
            
        }
    }
}
