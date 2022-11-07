using PetshopAPI.Models.Dtos;
using PetshopAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopAPI.Repository.Interfaces
{
    public interface IProfissionalRepository : IBaseRepository
    {
        Task<IEnumerable<ProfissionalDto>> GetProfissionais();
        Task<Profissional> GetProfissionalById(int id);
        Task<ProfissionalTipoAtendimento> GetProfissionalTipoAtendimento(int profissionalId, int tipoAtendimentoId);
    }
}
