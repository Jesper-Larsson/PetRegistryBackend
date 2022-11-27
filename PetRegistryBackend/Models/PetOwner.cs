namespace PetRegistryBackend.Models {
    public class PetOwner : Model{

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Pet> Pets { get; set; }

    }
}
