using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRegistryBackend.Controllers;
using PetRegistryBackend.Data;
using PetRegistryBackend.Models;

namespace modelRegistryBackend.Controllers
{
    [ApiController]
    public class EFCRUDController<ModelClass, ModelRepository> : ControllerBase, ICRUDController<ModelClass>
        where ModelRepository : ICRUDRepository<ModelClass>
        where ModelClass: Model
    {
        private readonly ModelRepository _repo;

        public EFCRUDController(ModelRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelClass>>> GetAll()
        {
            return Ok(await _repo.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModelClass>> Get(long id)
        {
            var model = await _repo.Get(id);
            return model == null? NotFound(): Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<ModelClass>> Post(ModelClass model)
        {
            var result = await _repo.Add(model);
            return result == -1 ? NotFound() : CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _repo.Delete(id);
            return result == -1 ? NotFound() : Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, ModelClass model) {
            if (id != model.Id) {
                return BadRequest();
            }
            var result = await _repo.Update(id, model);

            return result == -1 ? BadRequest() : NoContent();
        }
    }
}
