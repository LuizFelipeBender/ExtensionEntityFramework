using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetshopAPI.Data;
using PetshopAPI.Models.Entities;
using PetshopAPI.Repository;

namespace PetShopApi.Repository
{
    public class ConsultaRepository : BaseRepository, IConsultaRepository
    {
        private readonly AppDbContext _context;

        public ConsultaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async  Task<Consulta> GetConsultaById(int Id)
        {
            return await _context.Consultas
            .Include(x => x.Pet)
            .Include(x => x.Dono)
            .Include(x => x.Profissional)
            .Include(x => x.TipoAtendimento)
            .Where(x => x.Id == x.Id)
            .FirstOrDefaultAsync();         }

        public async Task<IEnumerable<Consulta>> GetConsultas()
        {
            return await _context.Consultas
            .Include(x => x.Pet)
            .Include(x => x.Dono)
            .Include(x => x.Profissional)
            .Include(x => x.TipoAtendimento)
            .ToListAsync();        }
    }
}