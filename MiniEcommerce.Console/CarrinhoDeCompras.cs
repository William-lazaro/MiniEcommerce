namespace MiniEcommerce.Console;

public class CarrinhoDeCompras
{
    private readonly List<(Produto Produto, int Quantidade)> itens = [];
    private bool finalizado;

    public IReadOnlyList<(Produto Produto, int Quantidade)> Itens => itens.AsReadOnly();
    public bool EstaFinalizado => finalizado;

    public void AdicionarProduto(Produto produto, int quantidade)
    {
        GarantirCarrinhoAberto();
        ArgumentNullException.ThrowIfNull(produto);

        if (quantidade <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantidade), "A quantidade deve ser maior que zero.");

        int quantidadeNoCarrinho = itens
            .Where(item => ReferenceEquals(item.Produto, produto))
            .Sum(item => item.Quantidade);

        if (quantidade + quantidadeNoCarrinho > produto.QuantidadeEstoque)
            throw new InvalidOperationException("Estoque insuficiente para essa quantidade.");

        int indice = itens.FindIndex(item => ReferenceEquals(item.Produto, produto));
        if (indice >= 0)
            itens[indice] = (produto, itens[indice].Quantidade + quantidade);
        else
            itens.Add((produto, quantidade));
    }

    public void RemoverProduto(Produto produto, int quantidade)
    {
        GarantirCarrinhoAberto();
        ArgumentNullException.ThrowIfNull(produto);

        if (quantidade <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantidade), "A quantidade deve ser maior que zero.");

        int indice = itens.FindIndex(item => ReferenceEquals(item.Produto, produto));
        if (indice < 0)
            throw new InvalidOperationException("O produto não está no carrinho.");

        var item = itens[indice];
        if (quantidade > item.Quantidade)
            throw new InvalidOperationException("A quantidade para remoção é maior que a quantidade no carrinho.");

        if (quantidade == item.Quantidade)
            itens.RemoveAt(indice);
        else
            itens[indice] = (produto, item.Quantidade - quantidade);
    }

    public decimal CalcularSubtotal() =>
        itens.Sum(item => item.Produto.Preco * item.Quantidade);

    public void FinalizarCompra()
    {
        GarantirCarrinhoAberto();

        // Valida todos os itens antes de alterar qualquer estoque.
        foreach (var item in itens)
        {
            if (item.Quantidade > item.Produto.QuantidadeEstoque)
                throw new InvalidOperationException($"Estoque insuficiente para {item.Produto.Nome}.");
        }

        foreach (var item in itens)
            item.Produto.DiminuirEstoque(item.Quantidade);

        finalizado = true;
    }

    private void GarantirCarrinhoAberto()
    {
        if (finalizado)
            throw new InvalidOperationException("O carrinho já foi finalizado.");
    }
}
