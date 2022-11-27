using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetRegistryBackend.Data;
using PetRegistryBackend.Models;

namespace PetRegistryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly PetRepository _repo;

        public PetsController(PetRepository repository)
        {
            _repo = repository;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return Ok(await _repo.GetAll());
        }

        // GET: api/Pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(long id)
        {
            var pet = await _repo.Get(id);
            return pet == null? NotFound(): Ok(pet);
        }

        // POST: api/Pets
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            var result = await _repo.Add(pet);
            return result == -1 ? NotFound() : CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(long id)
        {
            var result = await _repo.Delete(id);
            return result == -1 ? NotFound() : Ok();
        }

    }
}
