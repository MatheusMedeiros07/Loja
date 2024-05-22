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
                Genero = comprador.Genero.ToString(),
                DataNascimento = comprador.DataNascimento,
                Senha = comprador.Senha,
            };
        }

        public async Task<List<string>> AddCompradorAsync(CompradorDto compradorDto)
        {
            var errors = new List<string>();

            if (await _compradorRepository.CpfCnpjExistsAsync(compradorDto.CpfCnpj))
            {
                errors.Add("Este CPF/CNPJ já está cadastrado para outro Cliente");
            }

            if (await _compradorRepository.EmailExistsAsync(compradorDto.Email))
            {
                errors.Add("Este E-mail já está cadastrado para outro Cliente");
            }

            if (!compradorDto.Isento && !string.IsNullOrEmpty(compradorDto.InscricaoEstadual) && await _compradorRepository.InscricaoEstadualExistsAsync(compradorDto.InscricaoEstadual))
            {
                errors.Add("Esta Inscrição Estadual já está cadastrada para outro Cliente");
            }

            if (errors.Count == 0)
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
                    Genero = Enum.Parse<Genero>(compradorDto.Genero),
                    DataNascimento = compradorDto.DataNascimento,
                    Senha = compradorDto.Senha,
                };

                await _compradorRepository.AddAsync(comprador);
            }

            return errors;
        }

        public async Task<bool> CpfCnpjExistsAsync(string cpfCnpj)
        {
            return await _compradorRepository.CpfCnpjExistsAsync(cpfCnpj);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _compradorRepository.EmailExistsAsync(email);
        }

        public async Task<bool> InscricaoEstadualExistsAsync(string inscricaoEstadual)
        {
            return await _compradorRepository.InscricaoEstadualExistsAsync(inscricaoEstadual);
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
