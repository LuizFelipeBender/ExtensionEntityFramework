
using PetshopAPI.Models.Dtos;
using PetshopAPI.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetshopAPI.Repository.Interfaces
{
    public interface IDonoRepository : IBaseRepository
    {
        Task<IEnumerable<DonoDto>> GetDonosAsync();
        Task<Dono> GetDonosByIdAsync(int id);
    }
}
