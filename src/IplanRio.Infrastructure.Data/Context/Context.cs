using IplanRio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IplanRio.Infrastructure.Data.Context
{
    public class ContextIplanRio : DbContext, IDisposable
    {
        public DbSet<Shopping> Shopping { get; set; }

        public ContextIplanRio(DbContextOptions<ContextIplanRio> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shopping>().HasData(
                new Shopping
                {
                    Id = 1,
                    Nome = "Shopping Rio Sul",
                    Endereco = "Rua Lauro Müller, 116 - Botafogo, Rio de Janeiro - RJ, 22290-160",
                    HoraAbertura = "10:00",
                    HoraFechamento = "22:00"
                },

                new Shopping
                {
                    Id = 2,
                    Nome = "Shopping Carioca",
                    Endereco = "Av. Vicente de Carvalho, 909 - Vila da Penha, Rio de Janeiro - RJ, 21210-000",
                    HoraAbertura = "10:00",
                    HoraFechamento = "22:00"
                },

                new Shopping
                {
                    Id = 3,
                    Nome = "Shopping Tijuca",
                    Endereco = "Av. Maracanã, 987 - Tijuca, Rio de Janeiro - RJ, 20511-000",
                    HoraAbertura = "10:00",
                    HoraFechamento = "22:00"
                });
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
