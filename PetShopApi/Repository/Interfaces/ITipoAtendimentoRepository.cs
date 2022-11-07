using PetshopAPI.Models.Dtos;
using PetshopAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopAPI.Repository.Interfaces
{
    public interface ITipoAtendimentoRepository : IBaseRepository
    {
        Task<IEnumerable<TipoAtendimentoDto>> GetTipoAtendimentos();
        Task<TipoAtendimento> GetTipoAtendimentoById(int id);
    }
}
