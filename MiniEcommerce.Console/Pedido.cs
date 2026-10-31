namespace MiniEcommerce.Console;

public class Pedido
{
    private readonly CarrinhoDeCompras carrinho;
    private bool finalizado;

    public decimal Total { get; private set; }
    public bool EstaFinalizado => finalizado;

    public Pedido(CarrinhoDeCompras carrinho)
    {
        this.carrinho = carrinho ?? throw new ArgumentNullException(nameof(carrinho));
    }

    public void FinalizarCompra()
    {
        if (finalizado)
            throw new InvalidOperationException("Este pedido já foi finalizado.");

        Total = carrinho.CalcularSubtotal();
        carrinho.FinalizarCompra();
        finalizado = true;
    }
}
