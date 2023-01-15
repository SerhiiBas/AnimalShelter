using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AnimalShelter.Models.Animal
{
    public class AnimalPhoto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Photo { get; set; }
        public Animal Animal { get; set; }
        public int AnimalId { get; set; }
    }
}
