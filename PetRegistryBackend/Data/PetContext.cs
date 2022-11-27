using Microsoft.EntityFrameworkCore;
using PetRegistryBackend.Models;

namespace PetRegistryBackend.Data {
    public class PetContext : DbContext {
        public PetContext(DbContextOptions options) : base(options) {

        }

        public DbSet<Pet> Pets { get; set;}
    }
}
