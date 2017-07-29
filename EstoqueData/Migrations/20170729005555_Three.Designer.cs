using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EstoqueData.Data;

namespace EstoqueData.Migrations
{
    [DbContext(typeof(EstoqueContext))]
    [Migration("20170729005555_Three")]
    partial class Three
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EstoqueData.Models.Fornecedor", b =>
                {
                    b.Property<int>("FornecedorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Endereco");

                    b.Property<string>("Nome");

                    b.HasKey("FornecedorID");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("EstoqueData.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataEntrada");

                    b.Property<int>("FornecedorID");

                    b.Property<string>("Nome");

                    b.Property<int>("Preco");

                    b.Property<int>("Quantidade");

                    b.HasKey("ProdutoID");

                    b.HasIndex("FornecedorID");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("EstoqueData.Models.Produto", b =>
                {
                    b.HasOne("EstoqueData.Models.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
