using Loja.Domain.Entities;
using Loja.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Comprador> Compradores { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeia a entidade Comprador para a tabela Cliente
            modelBuilder.Entity<Comprador>().ToTable("Cliente");

            // Configura as entidades e suas propriedades
            modelBuilder.Entity<Comprador>()
                .Property(c => c.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Comprador>()
                .Property(c => c.NomeRazaoSocial)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("Nome");

            modelBuilder.Entity<Comprador>()
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Comprador>()
                .Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<Comprador>()
                .Property(c => c.DataCadastro)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Comprador>()
                .Property(c => c.TipoPessoa)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => v == "Fisica" ? TipoPessoa.Fisica : TipoPessoa.Juridica);

            modelBuilder.Entity<Comprador>()
                .Property(c => c.CpfCnpj)
                .IsRequired()
                .HasColumnName("CPF_CNPJ");

            modelBuilder.Entity<Comprador>()
                .Property(c => c.InscricaoEstadual)
                .HasMaxLength(15)
                .IsRequired(false);

            modelBuilder.Entity<Comprador>()
                .Property(c => c.Isento);

            modelBuilder.Entity<Comprador>()
                .Property(c => c.Genero)
                .HasConversion(
                    v => v.ToString(),
                    v => v == "Feminino" ? Genero.Feminino : v == "Masculino" ? Genero.Masculino : Genero.Outro)
                .IsRequired(false);

            modelBuilder.Entity<Comprador>()
                .Property(c => c.DataNascimento)
                .IsRequired(false);

            modelBuilder.Entity<Comprador>()
                .Property(c => c.Bloqueado)
                .IsRequired();

            modelBuilder.Entity<Comprador>()
                .Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
