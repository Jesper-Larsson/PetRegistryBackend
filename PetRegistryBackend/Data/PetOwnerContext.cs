using Microsoft.EntityFrameworkCore;
using PetRegistryBackend.Models;

namespace PetRegistryBackend.Data {
    public class PetOwnerContext : DbContext {
        public PetOwnerContext(DbContextOptions options) : base(options) {

        }

        public DbSet<PetOwner> PetOwners { get; set;}
    }
}
