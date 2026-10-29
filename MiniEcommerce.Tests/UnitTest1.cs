using System;
using Xunit;
using MiniEcommerce.Console;

namespace MiniEcommerce.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void CriarProduto_ComPrecoNegativo_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentException>(() =>
                new Produto("Teclado", -10, 5));
        }

        [Fact]
        public void CriarProduto_ComEstoqueNegativo_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentException>(() =>
                new Produto("Mouse", 50, -1));
        }

        [Fact]
        public void CriarProduto_ComDadosValidos_DeveSerCriado()
        {
            var produto = new Produto("Monitor", 500, 10);

            Assert.Equal("Monitor", produto.Nome);
            Assert.Equal(500, produto.Preco);
            Assert.Equal(10, produto.QuantidadeEstoque);
        }
    }
}