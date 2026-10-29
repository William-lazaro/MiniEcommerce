
using System;

namespace MiniEcommerce.Console
{
    public class Produto
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }

        public Produto(string nome, decimal preco, int quantidadeEstoque)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do produto é obrigatório.");

            if (preco < 0)
                throw new ArgumentException("O preço não pode ser negativo.");

            if (quantidadeEstoque < 0)
                throw new ArgumentException("O estoque não pode ser negativo.");

            Nome = nome;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }
    }
}
