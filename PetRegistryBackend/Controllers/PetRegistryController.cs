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
        public async Task<ActionResult<PetOwner>> GetOwnerByName(string name) {
            var result = await _repo.GetOwnerByName(name);
            return result == null ? NotFound() : Ok(result);
        }

        [Route("pet/{name}")]
        [HttpGet]
        public async Task<ActionResult<PetOwner>> GetOwnerByPetName(string name) {
            var result = await _repo.GetOwnerByPetName(name);
            return result == null ? NotFound() : Ok(result);
        }

    }
}
