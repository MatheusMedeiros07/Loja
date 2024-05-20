using Loja.Application.Dtos;
using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Enums;
using Loja.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Loja.Application.Services
{
    public class CompradorService(ICompradorRepository compradorRepository) : ICompradorService
    {
        private readonly ICompradorRepository _compradorRepository = compradorRepository;

        public async Task<List<CompradorDto>> GetAllCompradoresAsync()
        {
            var compradores = await _compradorRepository.GetAllAsync();
            return compradores.Select(c => new CompradorDto
            {
                Id = c.Id,
                NomeRazaoSocial = c.NomeRazaoSocial,
                Email = c.Email,
                Telefone = c.Telefone,
                DataCadastro = c.DataCadastro,
                Bloqueado = c.Bloqueado,
                TipoPessoa = c.TipoPessoa.ToString(),
                CpfCnpj = c.CpfCnpj,
                InscricaoEstadual = c.InscricaoEstadual,
                Isento = c.Isento,
                InscricaoEstadualPessoaFisica = c.InscricaoEstadualPessoaFisica,
                Genero = c.Genero.ToString(),
                DataNascimento = c.DataNascimento,
                Senha = c.Senha,
            }).ToList();
        }

        public async Task<CompradorDto?> GetCompradorByIdAsync(int id)
        {
            var comprador = await _compradorRepository.GetByIdAsync(id);
            if (comprador == null)
            {
                return null;
            }
            return new CompradorDto
            {
                Id = comprador.Id,
                NomeRazaoSocial = comprador.NomeRazaoSocial,
                Email = comprador.Email,
                Telefone = comprador.Telefone,
                DataCadastro = comprador.DataCadastro,
                Bloqueado = comprador.Bloqueado,
                TipoPessoa = comprador.TipoPessoa.ToString(),
                CpfCnpj = comprador.CpfCnpj,
                InscricaoEstadual = comprador.InscricaoEstadual,
                Isento = comprador.Isento,
                InscricaoEstadualPessoaFisica = comprador.InscricaoEstadualPessoaFisica,
                Genero = comprador.Genero.ToString(),
                DataNascimento = comprador.DataNascimento,
                Senha = comprador.Senha,
            };
        }

        public async Task AddCompradorAsync(CompradorDto compradorDto)
        {
            var comprador = new Comprador
            {
                NomeRazaoSocial = compradorDto.NomeRazaoSocial,
                Email = compradorDto.Email,
                Telefone = compradorDto.Telefone,
                DataCadastro = DateTime.Now, // Insere a data atual
                Bloqueado = compradorDto.Bloqueado,
                TipoPessoa = Enum.Parse<TipoPessoa>(compradorDto.TipoPessoa),
                CpfCnpj = compradorDto.CpfCnpj,
                InscricaoEstadual = compradorDto.InscricaoEstadual,
                Isento = compradorDto.Isento,
                InscricaoEstadualPessoaFisica = compradorDto.InscricaoEstadualPessoaFisica,
                Genero = Enum.Parse<Genero>(compradorDto.Genero),
                DataNascimento = compradorDto.DataNascimento,
                Senha = compradorDto.Senha,
            };

            await _compradorRepository.AddAsync(comprador);
        }

        public async Task UpdateCompradorAsync(CompradorDto compradorDto)
        {
            var comprador = await _compradorRepository.GetByIdAsync(compradorDto.Id);
            if (comprador == null)
            {
                // Handle the case where the comprador doesn't exist
                return;
            }

            comprador.NomeRazaoSocial = compradorDto.NomeRazaoSocial;
            comprador.Email = compradorDto.Email;
            comprador.Telefone = compradorDto.Telefone;
            comprador.Bloqueado = compradorDto.Bloqueado;
            comprador.TipoPessoa = Enum.Parse<TipoPessoa>(compradorDto.TipoPessoa);
            comprador.CpfCnpj = compradorDto.CpfCnpj;
            comprador.InscricaoEstadual = compradorDto.InscricaoEstadual;
            comprador.Isento = compradorDto.Isento;
            comprador.InscricaoEstadualPessoaFisica = compradorDto.InscricaoEstadualPessoaFisica;
            comprador.Genero = Enum.Parse<Genero>(compradorDto.Genero);
            comprador.DataNascimento = compradorDto.DataNascimento;
            comprador.Senha = compradorDto.Senha;

            await _compradorRepository.UpdateAsync(comprador);
        }

        public async Task DeleteCompradorAsync(int id)
        {
            await _compradorRepository.DeleteAsync(id);
        }
    }
}
