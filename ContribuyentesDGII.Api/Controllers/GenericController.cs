using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContribuyentesDGII.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly IGenericService<T> _service;
        public GenericController(IGenericService<T> service)
        {
            _service = service;
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
            var createdEntity = await _service.Create(entity);
            return createdEntity;
        }


        // PUT api/<GenericController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Update(int id, T entity)
        {
            var updatedEntity = await _service.Update(id, entity);
            if (updatedEntity == null)
            {
                return NotFound();
            }
            return Ok(updatedEntity);
        }

        // DELETE api/<GenericController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
