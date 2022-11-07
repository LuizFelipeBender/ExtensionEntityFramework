using System.Collections.Generic;

namespace PetshopAPI.Models.Entities
{
    public class Profissional : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }

        public uint CRV {get;set;}
        public bool Ativo { get; set; }
        public List<Consulta> Consultas { get; set; }
        public List<TipoAtendimento> TipoAtendimentos { get; set; }
    }
}
