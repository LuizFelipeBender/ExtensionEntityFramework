using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetshopAPI.Models.Entities;
using PetshopAPI.Repository.Interfaces;

namespace PetShopApi.Repository
{
    public interface IConsultaRepository:IBaseRepository
    {
        Task<IEnumerable<Consulta>> GetConsultas();
    
        Task<Consulta> GetConsultaById(int id);
    }
}