using MiniEcommerce.Console;
using Xunit;

namespace MiniEcommerce.Tests;

public class CatalogoTests
{
    [Fact]
    public void CadastrarProduto_DeveAdicionarAoCatalogo()
    {
        var catalogo = new Catalogo();
        catalogo.CadastrarProduto(new Produto("Mouse", 50m, 10));
        Assert.Single(catalogo.Produtos);
    }

    [Fact]
    public void CadastrarProduto_ComNomeDuplicado_DeveLancarExcecao()
    {
        var catalogo = new Catalogo();
        catalogo.CadastrarProduto(new Produto("Mouse", 50m, 10));
        Assert.Throws<InvalidOperationException>(() =>
            catalogo.CadastrarProduto(new Produto("mouse", 60m, 5)));
    }

    [Fact]
    public void BuscarPorNome_DeveIgnorarMaiusculasEMinusculas()
    {
        var catalogo = new Catalogo();
        var produto = new Produto("Mouse", 50m, 10);
        catalogo.CadastrarProduto(produto);
        Assert.Same(produto, catalogo.BuscarPorNome("MOUSE"));
    }

    [Fact]
    public void ListarDisponiveis_NaoDeveExibirProdutosSemEstoque()
    {
        var catalogo = new Catalogo();
        catalogo.CadastrarProduto(new Produto("Mouse", 50m, 10));
        catalogo.CadastrarProduto(new Produto("Teclado", 100m, 0));
        Assert.Single(catalogo.ListarDisponiveis());
    }
}
