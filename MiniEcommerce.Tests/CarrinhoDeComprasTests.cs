using System;
using Xunit;
using MiniEcommerce.Console;

namespace MiniEcommerce.Tests
{
    public class CarrinhoDeComprasTests
    {
        [Fact]
        public void AdicionarProduto_ComQuantidadeValida_DeveAdicionarAoCarrinho()
        {
            var produto = new Produto("Mouse", 50m, 10);
            var carrinho = new CarrinhoDeCompras();

            carrinho.AdicionarProduto(produto, 2);

            Assert.Equal(100m, carrinho.CalcularSubtotal());
        }

        [Fact]
        public void AdicionarProduto_ComQuantidadeMaiorQueEstoque_DeveLancarExcecao()
        {
            var produto = new Produto("Teclado", 100m, 3);
            var carrinho = new CarrinhoDeCompras();

            Assert.Throws<ArgumentException>(
                () => carrinho.AdicionarProduto(produto, 4));
        }

        [Fact]
        public void AdicionarProduto_ComQuantidadeZero_DeveLancarExcecao()
        {
            var produto = new Produto("Monitor", 500m, 5);
            var carrinho = new CarrinhoDeCompras();

            Assert.Throws<ArgumentException>(
                () => carrinho.AdicionarProduto(produto, 0));
        }
    }
}
