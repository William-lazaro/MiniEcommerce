using System;
using Xunit;
using MiniEcommerce.Console;

namespace MiniEcommerce.Tests
{
    public class PedidoTests
    {
        [Fact]
        public void FinalizarCompra_DeveCalcularTotalEDarBaixaNoEstoque()
        {
            var produto = new Produto("Mouse", 50m, 10);
            var carrinho = new CarrinhoDeCompras();
            carrinho.AdicionarProduto(produto, 2);

            var pedido = new Pedido(carrinho);
            pedido.FinalizarCompra();

            Assert.Equal(100m, pedido.Total);
            Assert.Equal(8, produto.QuantidadeEstoque);
        }

        [Fact]
        public void FinalizarCompra_DuasVezes_DeveImpedirBaixaDuplicada()
        {
            var produto = new Produto("Teclado", 100m, 5);
            var carrinho = new CarrinhoDeCompras();
            carrinho.AdicionarProduto(produto, 2);

            var pedido = new Pedido(carrinho);
            pedido.FinalizarCompra();

            Assert.Throws<InvalidOperationException>(
                () => pedido.FinalizarCompra());
        }
    }
}
