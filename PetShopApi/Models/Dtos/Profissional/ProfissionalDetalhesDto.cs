﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopAPI.Models.Dtos
{
    public class ProfissionalDetalhesDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }

        public uint CRV {get;set;}
        public int TotalConsultas { get; set; }
        public string[] TipoAtendimentos { get; set; }
    }
}
