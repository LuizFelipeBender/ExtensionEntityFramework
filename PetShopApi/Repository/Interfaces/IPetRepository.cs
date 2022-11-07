using PetshopAPI.Models.Dtos;
using PetshopAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopAPI.Repository.Interfaces
{
    public interface IPetRepository : IBaseRepository
    {
        Task<IEnumerable<PetDto>> GetPets();
        Task<Pet> GetPetById(int id);
        Task<DonosPets> GetDonoPets(int PetId, int DonoId );
    }
}
