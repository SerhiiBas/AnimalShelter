using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models.Animal
{
    public class AnimalTag
    {
        [Key]
        public int TagId { get; set; }
        public string Name { get; set; }
        public ICollection<Animal> Animals { get; set; }
        public int AnimalId { get; set; }
    }
}
