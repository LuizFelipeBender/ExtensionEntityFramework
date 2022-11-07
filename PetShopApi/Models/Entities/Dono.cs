using System.Collections.Generic;

namespace PetshopAPI.Models.Entities
{
    public class Dono: Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public List<Pet> Pets { get; set; }

        public List<Consulta> Consultas { get; set; }



    }
}