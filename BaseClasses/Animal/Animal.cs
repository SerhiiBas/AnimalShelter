using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AnimalShelter.Models.Animal
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }
        public string TypeOfAnimal  { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string Size { get; set; }
        public ICollection<AnimalTag> Tags { get; set; }
        public string History { get; set; }
        [MaybeNull]
        public AnimalPhoto Photo { get; set; }

}
}
