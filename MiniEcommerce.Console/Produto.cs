namespace MiniEcommerce.Console;

public class Produto
{
    public string Nome { get; }
    public decimal Preco { get; }
    public int QuantidadeEstoque { get; private set; }

    public Produto(string nome, decimal preco, int quantidadeEstoque)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do produto é obrigatório.", nameof(nome));
        if (preco < 0)
            throw new ArgumentException("O preço não pode ser negativo.", nameof(preco));
        if (quantidadeEstoque < 0)
            throw new ArgumentException("O estoque não pode ser negativo.", nameof(quantidadeEstoque));

        Nome = nome.Trim();
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
    }

    public void DiminuirEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantidade), "A quantidade deve ser maior que zero.");
        if (quantidade > QuantidadeEstoque)
            throw new InvalidOperationException("Estoque insuficiente.");

        QuantidadeEstoque -= quantidade;
    }

    public override string ToString() =>
        $"{Nome} | {Preco:C2} | Estoque: {QuantidadeEstoque}";
}
