using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetshopAPI.Models;
using PetShopApi.API.Models;
using PetShopApi.API.Services;
using RestSharp;

namespace PetshopAPI.Controllers
{
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController : ControllerBase
    {
        private const string ALL_POKEMON_URL = "https://pokeapi.co/api/v2/pokemon";
        private const string EXTERNAL_BASE_URL = "https://localhost:7235";
        private const string TOKEN = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        private readonly IPokeService _pokeService;
        private readonly IExternalService _externalService;
        public PokemonController(IPokeService pokeService, IExternalService externalService)
        {
            _pokeService = pokeService;
            _externalService = externalService;
        }

     
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit) {
            var client = new RestClient(ALL_POKEMON_URL);

            var request = new RestRequest("", Method.Get);
            request.AddQueryParameter("limit", limit);

            var result = await client.GetAsync<NamedAPIResourceList>(request);

            var viewModel = MapToViewModel(result);

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBayId(int id) {
            var client = new RestClient($"{ALL_POKEMON_URL}/{id}");

            var request = new RestRequest("", Method.Get);

            var result = await client.ExecuteAsync<Root>(request);

            return Ok(result);
        }

        // X-LuisDevBlog
        [HttpPost]
        public async Task<IActionResult> Post(Ping ping) {
            var client = new RestClient($"{EXTERNAL_BASE_URL}/api/random");

            var request = new RestRequest("", Method.Post)
                .AddJsonBody(ping)
                .AddHeader("Authorization", TOKEN)
                .AddHeader("X-LuisDevBlog", "https://luisdev.com.br");

            var result = await client.PostAsync(request);

            var json = JsonConvert.DeserializeObject<ExternalResponse>(result.Content);

            return Ok(json);
        }
        

        private PokemonListViewModel MapToViewModel(NamedAPIResourceList resourceList) {
            return new PokemonListViewModel {
                Count = resourceList.Count,
                Pokemons = resourceList.Results.Select(p => {
                    var lastSegment = new Uri(p.Url).Segments.Last(); // 73/
                    var id = lastSegment.Remove(lastSegment.Length - 1);

                    return new PokemonListItemViewModel { Name = p.Name, Id = int.Parse(id)};
                })
            };
        }
    }

    public class Ping {
        public string Message { get; set; }
    }

    public class ExternalResponse {
        public List<string> Headers { get; set; }
        public Ping Data { get; set; }
    }
}