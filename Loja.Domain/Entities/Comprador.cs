﻿using Loja.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Loja.Domain.Entities
{
    public class Comprador
    {
        public int Id { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Bloqueado { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string? InscricaoEstadual { get; set; }
        public bool Isento { get; set; }
        public Genero? Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Senha { get; set; }
    }
}
