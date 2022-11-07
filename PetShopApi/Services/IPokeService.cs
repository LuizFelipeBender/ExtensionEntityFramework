using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetShopApi.API.Models;
using Refit;

namespace PetShopApi.API.Services
{
    public interface IPokeService
    {
        [Get("/pokemon")]
        Task<NamedAPIResourceList> GetAll(int limit);
        [Get("/pokemon/{id}")]
        Task<Root> GetById(int id);
    }
}