using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetRegistryBackend.Models;

namespace PetRegistryBackend.Controllers {
    public interface ICRUDController<ModeClass> {

        [HttpGet]
        public Task<ActionResult<IEnumerable<ModeClass>>> GetAll();

        [HttpGet("{id}")]
        public Task<ActionResult<ModeClass>> Get(long id);

        [HttpPost]
        public Task<ActionResult<ModeClass>> Post(ModeClass model);

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(long id);
    }
}
