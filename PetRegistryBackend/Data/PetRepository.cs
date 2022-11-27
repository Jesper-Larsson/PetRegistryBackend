using Microsoft.EntityFrameworkCore;
using PetRegistryBackend.Models;
using System;
using System.Drawing;

namespace PetRegistryBackend.Data {
    public class PetRepository: EFCRUDRepository<Pet, PetContext> {
        public PetRepository(PetContext context) : base(context) {

        }
    }
}
