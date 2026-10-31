using MiniEcommerce.Console;
using Xunit;

namespace MiniEcommerce.Tests;

public class ProdutoTests
{
    [Fact]
    public void CriarProduto_ComDadosValidos_DeveSerCriado()
    {
        var produto = new Produto("Monitor", 500m, 10);
        Assert.Equal("Monitor", produto.Nome);
        Assert.Equal(500m, produto.Preco);
        Assert.Equal(10, produto.QuantidadeEstoque);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void CriarProduto_SemNome_DeveLancarExcecao(string nome) =>
        Assert.Throws<ArgumentException>(() => new Produto(nome, 10m, 1));

    [Fact]
    public void CriarProduto_ComPrecoNegativo_DeveLancarExcecao() =>
        Assert.Throws<ArgumentException>(() => new Produto("Teclado", -10m, 5));

    [Fact]
    public void CriarProduto_ComEstoqueNegativo_DeveLancarExcecao() =>
        Assert.Throws<ArgumentException>(() => new Produto("Mouse", 50m, -1));

    [Fact]
    public void DiminuirEstoque_ComQuantidadeValida_DeveAtualizarEstoque()
    {
        var produto = new Produto("Mouse", 50m, 5);
        produto.DiminuirEstoque(2);
        Assert.Equal(3, produto.QuantidadeEstoque);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void DiminuirEstoque_ComQuantidadeInvalida_DeveLancarExcecao(int quantidade)
    {
        var produto = new Produto("Mouse", 50m, 5);
        Assert.Throws<ArgumentOutOfRangeException>(() => produto.DiminuirEstoque(quantidade));
    }

    [Fact]
    public void DiminuirEstoque_AcimaDoDisponivel_DeveLancarExcecao()
    {
        var produto = new Produto("Mouse", 50m, 2);
        Assert.Throws<InvalidOperationException>(() => produto.DiminuirEstoque(3));
    }
}
