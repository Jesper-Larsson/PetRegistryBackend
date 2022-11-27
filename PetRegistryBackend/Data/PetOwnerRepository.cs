using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PetRegistryBackend.Models;
using System;
using System.Drawing;

namespace PetRegistryBackend.Data {
    public class PetOwnerRepository: EFCRUDRepository<PetOwner, PetOwnerContext> {
        public PetOwnerRepository(PetOwnerContext context) : base(context) {

        }
        public async Task<PetOwner> GetOwnerByName(string name) {
            return await _context.PetOwners.Where(owner => owner.FirstName.Equals(name)
            || owner.LastName.Equals(name))
                .FirstOrDefaultAsync();
        }

        public async Task<PetOwner> GetOwnerByPetName(string name) {
            return await _context.PetOwners.Where(owner => owner.Pets.Select((pet) => pet.Name)
            .Contains(name))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PetOwner>> GetAllOwnersAndPets() {
            return await _context.PetOwners.Include(owner => owner.Pets)
                .ToListAsync();
        }

        public async Task<PetOwner> GetOwnerAndPets(long id) {
            var result = await _context.PetOwners.FindAsync(id);
            if (result != null) {
                _context.Entry(result)
                    .Reference(owner => owner.Pets)
                    .Load();
            }
            return result;

        }
    }
}
