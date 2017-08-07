using EstoqueData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueData.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EstoqueContext context)
        {
            context.Database.EnsureCreated();

            if (context.Produtos.Any())
            {
                return;
            }

            var Produtos = new Produto[]
            {
                new Produto{ Nome="Geladeira", Quantidade=12, Preco=22, DataEntrada=DateTime.Parse("05-08-2017"), FornecedorID=1 },
                new Produto{ Nome="Cama", Quantidade=3, Preco=1300, DataEntrada=DateTime.Parse("06-08-2017"), FornecedorID=1 },
                new Produto{ Nome="Maquina de lavar", Quantidade=5, DataEntrada=DateTime.Parse("07-08-2017"), Preco=2000, FornecedorID=1 }
            };

            foreach (Produto p in Produtos)
            {
                context.Produtos.Add(p);
            }

            context.SaveChanges();

            var Fornecedores = new Fornecedor[]
            {
                new Fornecedor{ Nome="Pedro", Endereco="Brasilia"},
                new Fornecedor{ Nome="Julio", Endereco="São paulo"}
            };

            foreach (Fornecedor f in Fornecedores)
            {
                context.Fornecedores.Add(f);
            }

            context.SaveChanges();
        }
    }
}
