using Microsoft.AspNetCore.Mvc;
using modelRegistryBackend.Controllers;
using PetRegistryBackend.Data;
using PetRegistryBackend.Models;

namespace PetRegistryBackend.Controllers {
    [Route("api/petregistry")]
    [ApiController]
    public class PetRegistryController: EFCRUDController<PetOwner, PetOwnerRepository> {

        private readonly PetOwnerRepository _repo;

        public PetRegistryController(PetOwnerRepository repo) :base(repo){
            _repo = repo;
        }

        [Route("owner/{name}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetOwner>>> GetOwnerByName(string name) {
            var result = await _repo.GetOwnerByName(name);
            return result == null ? NotFound() : Ok(result);
        }

        [Route("pet/{name}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetOwner>>> GetOwnerByPetName(string name) {
            var result = await _repo.GetOwnerByPetName(name);
            return result == null ? NotFound() : Ok(result);
        }
        
        [Route("ownerandpets/")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetOwner>>> GetAllOwnersAndPets() {
            var result = await _repo.GetAllOwnersAndPets();
            return result == null ? NotFound() : Ok(result);
        }

        [Route("ownerandpets/{id}")]
        [HttpGet]
        public async Task<ActionResult<PetOwner>> GetOwnerAndPets(long id) {
            var result = await _repo.GetOwnerAndPets(id);
            return result == null? NotFound() : Ok(result);
        }

        [HttpPut("ownerandpets/{id}")]
        public async Task<IActionResult> UpdateOwnerAndPets(long id, PetOwner owner) {
            if (id != owner.Id) {
                return BadRequest();
            }
            var result = await _repo.UpdateOwnerAndPets(id, owner);

            return result == -1 ? BadRequest() : NoContent();
        }

    }
}
