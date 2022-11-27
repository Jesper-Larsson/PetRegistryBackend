namespace PetRegistryBackend.Models {
    public class Pet : Model{
        public string Name { get; set; }

        public Pet(string name) {
            Name = name;
        }
    }
}
