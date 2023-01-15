namespace AnimalShelter.Models.Animal
{
    public class AnimalTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Animal> Animals { get; set; }
        public int AnimalId { get; set; }
    }
}
