using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopAPI.Models.Dtos
{
    public class PetAtualizarDto
    {
        public string Nome { get; set; }
        public string Altura { get; set; }
        public string Peso { get; set; }
        public int Idade { get; set; }
        public string Raca { get; set; }
    }
}
