using MiniEcommerce.Console;
using Xunit;

namespace MiniEcommerce.Tests;

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
        Assert.True(pedido.EstaFinalizado);
    }

    [Fact]
    public void FinalizarCompra_DuasVezes_DeveImpedirBaixaDuplicada()
    {
        var produto = new Produto("Teclado", 100m, 5);
        var carrinho = new CarrinhoDeCompras();
        carrinho.AdicionarProduto(produto, 2);
        var pedido = new Pedido(carrinho);
        pedido.FinalizarCompra();

        Assert.Throws<InvalidOperationException>(() => pedido.FinalizarCompra());
        Assert.Equal(3, produto.QuantidadeEstoque);
    }

    [Fact]
    public void CriarPedido_SemCarrinho_DeveLancarExcecao() =>
        Assert.Throws<ArgumentNullException>(() => new Pedido(null!));

    [Fact]
    public void FinalizarPedido_ComCarrinhoVazio_DeveTotalizarZero()
    {
        var pedido = new Pedido(new CarrinhoDeCompras());
        pedido.FinalizarCompra();
        Assert.Equal(0m, pedido.Total);
    }
}
