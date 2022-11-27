using Microsoft.EntityFrameworkCore;
using PetRegistryBackend.Models;

namespace PetRegistryBackend.Data
{
    public abstract class ModelContext<ModelClass> : DbContext
        where ModelClass : Model
    {
        public ModelContext(DbContextOptions options) : base(options)
        {

        }
        //todo: remove this class?
        // skip this class
    }
}
