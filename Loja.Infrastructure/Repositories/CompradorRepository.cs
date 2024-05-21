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
    public class CompradorRepository(ApplicationDbContext context) : ICompradorRepository
    {
        private readonly ApplicationDbContext _context = context;

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
            try
            {
                await _context.Compradores.AddAsync(comprador);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                // Log the exception
                throw new Exception("Erro ao adicionar comprador: " + dbEx.InnerException?.Message ?? dbEx.Message, dbEx);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Erro ao adicionar comprador: " + ex.Message, ex);
            }
        }

        public async Task<bool> CpfCnpjExistsAsync(string cpfCnpj)
        {
            return await _context.Compradores.AnyAsync(c => c.CpfCnpj == cpfCnpj);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Compradores.AnyAsync(c => c.Email == email);
        }

        public async Task<bool> InscricaoEstadualExistsAsync(string inscricaoEstadual)
        {
            return await _context.Compradores.AnyAsync(c => c.InscricaoEstadual == inscricaoEstadual);
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
