namespace MiniEcommerce.Console;

public class Catalogo
{
    private readonly List<Produto> produtos = [];

    public IReadOnlyList<Produto> Produtos => produtos.AsReadOnly();

    public void CadastrarProduto(Produto produto)
    {
        ArgumentNullException.ThrowIfNull(produto);

        if (produtos.Any(p => string.Equals(p.Nome, produto.Nome, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException("Já existe um produto com esse nome.");

        produtos.Add(produto);
    }

    public Produto? BuscarPorNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return null;

        return produtos.FirstOrDefault(p =>
            string.Equals(p.Nome, nome.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public IReadOnlyList<Produto> ListarDisponiveis() =>
        produtos.Where(p => p.QuantidadeEstoque > 0).ToList().AsReadOnly();
}
