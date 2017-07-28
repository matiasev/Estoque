using EstoqueData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueData.Data
{
    public class EstoqueContext: DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Fornecedor>().ToTable("Fornecedor");
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
