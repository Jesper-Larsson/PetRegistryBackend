using Microsoft.EntityFrameworkCore;
namespace PetRegistryBackend.Models {
    public class PetContext : DbContext{
        public PetContext(DbContextOptions<PetContext> options) : base(options) {

        }
        //todo: add default pets??

        public DbSet<Pet> Pets { get; set; } = null;
    }
}
