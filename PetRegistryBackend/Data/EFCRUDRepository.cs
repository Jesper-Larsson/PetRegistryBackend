using Microsoft.EntityFrameworkCore;
using PetRegistryBackend.Models;

namespace PetRegistryBackend.Data
{
    public abstract class EFCRUDRepository<ModelClass, ContextClass> : ICRUDRepository<ModelClass>
        
        where ModelClass : Model
        where ContextClass : DbContext
        {
        protected ContextClass _context;
        public EFCRUDRepository(ContextClass context) {
            _context = context;
        }

        public async Task<IEnumerable<ModelClass>> GetAll() {
            return await _context.Set<ModelClass>().ToListAsync();
        }

        public async Task<ModelClass> Get(long id) {
            if (_context.Set<ModelClass>() == null) {
                return default(ModelClass);
            }
            return await _context.Set<ModelClass>().FindAsync(id);
        }
        public async Task<int> Add(ModelClass model) {
            if (_context.Model == null) {
                return -1;
            }
            _context.Set<ModelClass>().Add(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(long id) {

            if (_context.Set<ModelClass>() == null) {
                return -1;
            }
            var pet = await _context.Set<ModelClass>().FindAsync(id);
            if (pet == null) {
                return -1;
            }
            _context.Set<ModelClass>().Remove(pet);
            return await _context.SaveChangesAsync();
        }
    }
}
