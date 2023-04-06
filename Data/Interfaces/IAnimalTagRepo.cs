using AnimalShelter.Models.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IAnimalTagRepo
    {
        Task<AnimalTag> GetById(int id);
        Task<AnimalTag> GetByName(string name);
    }
}
