using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetshopAPI.Controllers;
using PetShopApi.Controllers;
using Refit;

namespace PetShopApi.API.Services
{
    public interface IExternalService
    {
        [Post("/api/random")]
        [Headers("X-LuisDevBlog: https://luisdev.com.br")]
        Task<ExternalResponse> GetData(Ping ping, [Header("Authorization")] string token);
    }
}