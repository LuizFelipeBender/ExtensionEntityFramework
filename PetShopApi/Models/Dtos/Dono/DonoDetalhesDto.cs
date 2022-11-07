
using PetshopAPI.Models.Entities;
using System.Collections.Generic;

namespace PetshopAPI.Models.Dtos
{
    public class DonoDetalhesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public List<PetDetalhesDto> Pets { get; set; }

    }
}