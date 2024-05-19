using Loja.Domain.Entities;
using Loja.Domain.Interfaces;
using Loja.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infrastructure.Repositories
{
    public class CompradorRepository : ICompradorRepository
    {
        private readonly ApplicationDbContext _context;

        public CompradorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comprador>> GetAllAsync()
        {
            return await _context.Compradores.ToListAsync();
        }

        public async Task<Comprador?> GetByIdAsync(int id)
        {
            return await _context.Compradores.FindAsync(id);
        }

        public async Task AddAsync(Comprador comprador)
        {
            await _context.Compradores.AddAsync(comprador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comprador comprador)
        {
            _context.Compradores.Update(comprador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comprador = await _context.Compradores.FindAsync(id);
            if (comprador != null)
            {
                _context.Compradores.Remove(comprador);
                await _context.SaveChangesAsync();
            }
        }
    }
}
