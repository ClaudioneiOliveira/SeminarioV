﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SeminarioV.Models
{
    public partial class SeminarioVDbContext : DbContext
    {
        public virtual DbSet<ControleEmprestimos> ControleEmprestimos { get; set; }
        public virtual DbSet<Editoras> Editoras { get; set; }
        public virtual DbSet<Emprestimos> Emprestimos { get; set; }
        public virtual DbSet<Livros> Livros { get; set; }
        public virtual DbSet<MultaEmprestimos> MultaEmprestimos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=claudioneio.database.windows.net;Database=SeminarioV;user id=SeminarioV;password=seminario5!@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ControleEmprestimos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataPrevistaDevolucao)
                    .HasColumnName("dataPrevistaDevolucao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataRealDevolucao)
                    .HasColumnName("dataRealDevolucao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataRetirada)
                    .HasColumnName("dataRetirada")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEmprestimo).HasColumnName("idEmprestimo");
            });

            modelBuilder.Entity<Editoras>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("char(255)");
            });

            modelBuilder.Entity<Emprestimos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataPrevistaDevolucao)
                    .HasColumnName("dataPrevistaDevolucao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataRealDevolucao)
                    .HasColumnName("dataRealDevolucao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataRetirada)
                    .HasColumnName("dataRetirada")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdLivro).HasColumnName("idLivro");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            });

            modelBuilder.Entity<Livros>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ano).HasColumnName("ano");

                entity.Property(e => e.CodBarras)
                    .HasColumnName("codBarras")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Editora).HasColumnName("editora");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("isbn")
                    .HasColumnType("char(255)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("char(255)");

                entity.Property(e => e.Paginas).HasColumnName("paginas");

                entity.Property(e => e.Resenha)
                    .IsRequired()
                    .HasColumnName("resenha")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MultaEmprestimos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEmprestimo).HasColumnName("idEmprestimo");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(12, 2)");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("char(255)");
            });
        }
    }
}
