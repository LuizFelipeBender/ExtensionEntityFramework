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
    public class DonoRepository : BaseRepository, IDonoRepository
    {
        private readonly AppDbContext _context;

        public DonoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DonoDto>> GetDonosAsync()
        {
            return await _context.Donos
                .Select(x => new DonoDto { Id = x.Id, Nome = x.Nome })
                .ToListAsync();
        }

        public async Task<Dono> GetDonosByIdAsync(int id)
        {
            return await _context.Donos.Include(x => x.Pets)
                         .ThenInclude(c => c.Consultas)
                        .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

    }
}
