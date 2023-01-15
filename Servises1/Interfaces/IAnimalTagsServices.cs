using AnimalShelter.Models.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servises.Interfaces
{
    public interface IAnimalTagsServices
    {
        public Task<AnimalTag> GetById(int id);
    }
}
