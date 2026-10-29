using System;
using System.Collections.Generic;

namespace MiniEcommerce.Console
{
    public class CarrinhoDeCompras
    {
        private readonly List<(Produto Produto, int Quantidade)> itens = new();

        public void AdicionarProduto(Produto produto, int quantidade)
        {
            if (produto == null)
                throw new ArgumentException("O produto é obrigatório.");

            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            int quantidadeNoCarrinho = 0;

            foreach (var item in itens)
            {
                if (item.Produto == produto)
                    quantidadeNoCarrinho += item.Quantidade;
            }

            if (quantidade + quantidadeNoCarrinho > produto.QuantidadeEstoque)
                throw new ArgumentException("Estoque insuficiente.");

            itens.Add((produto, quantidade));
        }

        public decimal CalcularSubtotal()
        {
            decimal subtotal = 0;

            foreach (var item in itens)
            {
                subtotal += item.Produto.Preco * item.Quantidade;
            }

            return subtotal;
        }
    }
}