using Microsoft.AspNetCore.Mvc;
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
            return await _context.PetOwners.Where(owner => owner.FirstName.Contains(name)
            || owner.LastName.Contains(name))
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
                    .Collection(owner => owner.Pets)
                    .Load();
            }
            return result;

        }
        public async Task<int> UpdateOwnerAndPets(long id, PetOwner owner) {
                if (id != owner.Id) {
                    return -1;
                }
                if (PetOwnerExists(owner.Id)) {
                    _context.Entry(owner).State = EntityState.Modified;
                }
                var petsInDb = await _context.PetOwners.Where(owner => owner.Id == id).ToListAsync();
                foreach(var pet in owner.Pets) {
                    if (PetExists(pet.Id)) {
                        _context.Entry(pet).State = EntityState.Modified;
                    }
                    else {
                        _context.Entry(pet).State = EntityState.Added;
                    }
                }
                foreach(var dbPet in petsInDb) {
                    if(!owner.Pets.Select(pet => pet.Id).Contains(dbPet.Id)) {
                        if (PetExists(dbPet.Id)) {
                            var petToDelete = await _context.Pets.FindAsync(id);
                            _context.Entry(petToDelete).State = EntityState.Deleted;
                        }
                    }
                }
                try {
                    return await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    return -1;
                }
            }
        private bool PetOwnerExists(long id) {
            return (_context.PetOwners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private bool PetExists(long id) {
            return (_context.Pets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
