using Loja.Application.Dtos;

namespace Loja.Application.Interfaces
{
    public interface ICompradorService
    {
        Task<List<CompradorDto>> GetAllCompradoresAsync();
        Task<CompradorDto?> GetCompradorByIdAsync(int id);
        Task AddCompradorAsync(CompradorDto comprador);
        Task UpdateCompradorAsync(CompradorDto comprador);
        Task DeleteCompradorAsync(int id);
        Task<bool> CpfCnpjExistsAsync(string cpfCnpj);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> InscricaoEstadualExistsAsync(string inscricaoEstadual);
    }
}
