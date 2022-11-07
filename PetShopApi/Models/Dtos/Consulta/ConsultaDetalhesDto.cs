using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PetshopAPI.Models.Dtos
{
    public class ConsultaDetalhesDto
    {
        public int Id { get; set; }
        public DateTime DataHorario { get; set;} 
        public string Descricao { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public TipoAtendimentoDto TipoAtendimento { get; set; }
        public ProfissionalDto Profissional { get; set; }
        public PetDto Pet { get; set; }
        public DonoDto Dono { get; set; }

    }
}
