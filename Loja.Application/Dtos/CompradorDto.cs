using System.ComponentModel.DataAnnotations;

namespace Loja.Application.Dtos
{
    public class CompradorDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome/Razão Social é obrigatório.")]
        public string NomeRazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo E-mail não é um endereço de e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Bloqueado { get; set; }
        public string TipoPessoa { get; set; }

        [Required(ErrorMessage = "O campo CPF e CPNJ é obrigatório.")]
        public string CpfCnpj { get; set; }
        public string? InscricaoEstadual { get; set; }
        public bool Isento { get; set; }
        public string? Genero { get; set; }
        public DateTime? DataNascimento { get; set; }

        [StringLength(15, MinimumLength = 8, ErrorMessage = "A Senha deve ter entre 8 e 15 caracteres.")]
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Senha { get; set; }

        public string? ConfirmacaoSenha { get; set; }
    }
}