using System.Collections.Generic;

namespace PetshopAPI.Models.Entities
{
    public class Pet : Base
    {
        public string Nome { get; set; }
        public string Altura { get; set; }
        public string Peso { get; set; }
        public int Idade { get; set; }

        public string Raca { get; set; }

        public List<Consulta> Consultas { get; set; }

        public List<Dono> Donos { get; set; }

    }
}
