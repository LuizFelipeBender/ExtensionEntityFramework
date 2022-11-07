using PetshopAPI.Data;
using PetshopAPI.Models.Dtos;
using PetshopAPI.Models.Entities;
using PetshopAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetshopAPI.Repository
{
    public class TipoAtendimentoRepository : BaseRepository, ITipoAtendimentoRepository
    {
        private readonly AppDbContext _context;

        public TipoAtendimentoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TipoAtendimentoDto>> GetTipoAtendimentos()
        {
            return await _context.TipoAtendimentos
                .Select(x => new TipoAtendimentoDto { Id = x.Id, Nome = x.Nome, Ativa = x.Ativa })
                .ToListAsync();
        }
        public async Task<TipoAtendimento> GetTipoAtendimentoById(int id)
        {
            return await _context.TipoAtendimentos
                .Include(x => x.Profissionais)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }        
    }
}
