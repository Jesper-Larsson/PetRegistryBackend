using Microsoft.AspNetCore.Mvc;
using modelRegistryBackend.Controllers;
using PetRegistryBackend.Data;
using PetRegistryBackend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetRegistryBackend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController: EFCRUDController<Pet, PetRepository> {

        private readonly PetRepository _repo;

        public PetsController(PetRepository repo) :base(repo){
            _repo = repo;
        }
    }
}
