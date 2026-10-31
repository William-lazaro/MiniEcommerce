using MiniEcommerce.Console;
using Xunit;

namespace MiniEcommerce.Tests;

public class CarrinhoDeComprasTests
{
    [Fact]
    public void AdicionarProduto_ComQuantidadeValida_DeveAdicionarAoCarrinho()
    {
        var produto = new Produto("Mouse", 50m, 10);
        var carrinho = new CarrinhoDeCompras();
        carrinho.AdicionarProduto(produto, 2);
        Assert.Equal(100m, carrinho.CalcularSubtotal());
        Assert.Single(carrinho.Itens);
    }

    [Fact]
    public void AdicionarProduto_Repetido_DeveSomarQuantidades()
    {
        var produto = new Produto("Mouse", 50m, 10);
        var carrinho = new CarrinhoDeCompras();
        carrinho.AdicionarProduto(produto, 2);
        carrinho.AdicionarProduto(produto, 3);
        Assert.Equal(250m, carrinho.CalcularSubtotal());
        Assert.Equal(5, carrinho.Itens[0].Quantidade);
    }

    [Fact]
    public void AdicionarProduto_ComQuantidadeMaiorQueEstoque_DeveLancarExcecao()
    {
        var produto = new Produto("Teclado", 100m, 3);
        var carrinho = new CarrinhoDeCompras();
        Assert.Throws<InvalidOperationException>(() => carrinho.AdicionarProduto(produto, 4));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void AdicionarProduto_ComQuantidadeInvalida_DeveLancarExcecao(int quantidade)
    {
        var produto = new Produto("Monitor", 500m, 5);
        var carrinho = new CarrinhoDeCompras();
        Assert.Throws<ArgumentOutOfRangeException>(() => carrinho.AdicionarProduto(produto, quantidade));
    }

    [Fact]
    public void RemoverProduto_Parcialmente_DeveAtualizarSubtotal()
    {
        var produto = new Produto("Mouse", 50m, 10);
        var carrinho = new CarrinhoDeCompras();
        carrinho.AdicionarProduto(produto, 4);
        carrinho.RemoverProduto(produto, 1);
        Assert.Equal(150m, carrinho.CalcularSubtotal());
        Assert.Equal(3, carrinho.Itens[0].Quantidade);
    }

    [Fact]
    public void RemoverProduto_Totalmente_DeveRetirarItem()
    {
        var produto = new Produto("Mouse", 50m, 10);
        var carrinho = new CarrinhoDeCompras();
        carrinho.AdicionarProduto(produto, 2);
        carrinho.RemoverProduto(produto, 2);
        Assert.Empty(carrinho.Itens);
    }

    [Fact]
    public void RemoverProduto_QuantidadeMaiorQueCarrinho_DeveLancarExcecao()
    {
        var produto = new Produto("Mouse", 50m, 10);
        var carrinho = new CarrinhoDeCompras();
        carrinho.AdicionarProduto(produto, 1);
        Assert.Throws<InvalidOperationException>(() => carrinho.RemoverProduto(produto, 2));
    }

    [Fact]
    public void CarrinhoFinalizado_NaoDeveAceitarNovosItens()
    {
        var produto = new Produto("Mouse", 50m, 10);
        var carrinho = new CarrinhoDeCompras();
        carrinho.AdicionarProduto(produto, 1);
        carrinho.FinalizarCompra();
        Assert.Throws<InvalidOperationException>(() => carrinho.AdicionarProduto(produto, 1));
    }
}
