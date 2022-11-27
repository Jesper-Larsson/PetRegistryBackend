using Microsoft.EntityFrameworkCore;
using PetRegistryBackend.Models;

namespace PetRegistryBackend.Data {
    public interface ICRUDRepository<T> {
        public Task<IEnumerable<T>> GetAll();

        public Task<T> Get(long id);
        public Task<int> Add(T model);

        public Task<int> Delete(long id);
    }
}
