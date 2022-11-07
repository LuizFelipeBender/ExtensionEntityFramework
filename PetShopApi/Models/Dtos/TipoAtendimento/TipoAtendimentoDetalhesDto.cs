using System.Collections.Generic;

namespace PetshopAPI.Models.Dtos
{
    public class TipoAtendimentoDetalhesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; }
        public List<ProfissionalDto> Profissionais { get; set; }
    }
}
