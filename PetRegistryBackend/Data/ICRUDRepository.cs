using Microsoft.EntityFrameworkCore;
using PetRegistryBackend.Models;

namespace PetRegistryBackend.Data {
    public interface ICRUDRepository<ModelClass> {
        public Task<IEnumerable<ModelClass>> GetAll();

        public Task<ModelClass> Get(long id);
        public Task<int> Add(ModelClass model);

        public Task<int> Delete(long id);

        public Task<int> Update(long id, ModelClass model);
    }
}
