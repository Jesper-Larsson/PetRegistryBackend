using Microsoft.EntityFrameworkCore;
using PetRegistryBackend.Models;
using System.Drawing;

namespace PetRegistryBackend.Data {
    public class PetRepository {
        PetContext _context;
        public PetRepository(PetContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Pet>> GetAllPets() {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet> Get(long id) {
            if (_context.Pets == null) {
                return null;
            }
            return await _context.Pets.FindAsync(id);
        }
        public async Task<int> Add(Pet pet) {
            if (_context.Pets == null) {
                return -1;
            }
            _context.Pets.Add(pet);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePet(long id) {

            if (_context.Pets == null) {
                return -1;
            }
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) {
                return -1;
            }
            _context.Pets.Remove(pet);
            return await _context.SaveChangesAsync();
        }
    }
}
