using Loja.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.Interfaces
{
    public interface ICompradorRepository
    {
        Task<List<Comprador>> GetAllAsync();
        Task<Comprador?> GetByIdAsync(int id);
        Task AddAsync(Comprador comprador);
        Task UpdateAsync(Comprador comprador);
        Task DeleteAsync(int id);
    }
}
