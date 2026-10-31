using System.Globalization;

namespace MiniEcommerce.Console;

internal static class Program
{
    private static readonly CultureInfo Cultura = CultureInfo.GetCultureInfo("pt-BR");

    private static void Main()
    {
        var catalogo = new Catalogo();
        var carrinho = new CarrinhoDeCompras();

        CarregarProdutosDeExemplo(catalogo);

        bool executando = true;
        while (executando)
        {
            System.Console.Clear();
            System.Console.WriteLine("=================================");
            System.Console.WriteLine("        MINI E-COMMERCE");
            System.Console.WriteLine("=================================");
            System.Console.WriteLine("1 - Cadastrar produto");
            System.Console.WriteLine("2 - Exibir catálogo");
            System.Console.WriteLine("3 - Adicionar produto ao carrinho");
            System.Console.WriteLine("4 - Remover produto do carrinho");
            System.Console.WriteLine("5 - Visualizar carrinho");
            System.Console.WriteLine("6 - Finalizar pedido");
            System.Console.WriteLine("0 - Sair");
            System.Console.Write("\nEscolha uma opção: ");

            switch (System.Console.ReadLine())
            {
                case "1": CadastrarProduto(catalogo); break;
                case "2": ExibirCatalogo(catalogo); break;
                case "3": AdicionarAoCarrinho(catalogo, carrinho); break;
                case "4": RemoverDoCarrinho(catalogo, carrinho); break;
                case "5": ExibirCarrinho(carrinho); break;
                case "6":
                    FinalizarPedido(carrinho);
                    if (carrinho.EstaFinalizado)
                    {
                        System.Console.WriteLine("\nEste carrinho foi finalizado. Reinicie a aplicação para uma nova compra.");
                        executando = false;
                    }
                    break;
                case "0": executando = false; break;
                default: System.Console.WriteLine("Opção inválida."); Pausar(); break;
            }
        }
    }

    private static void CarregarProdutosDeExemplo(Catalogo catalogo)
    {
        catalogo.CadastrarProduto(new Produto("Mouse", 59.90m, 10));
        catalogo.CadastrarProduto(new Produto("Teclado", 129.90m, 8));
        catalogo.CadastrarProduto(new Produto("Monitor", 899.00m, 5));
    }

    private static void CadastrarProduto(Catalogo catalogo)
    {
        try
        {
            System.Console.Write("Nome: ");
            string nome = System.Console.ReadLine() ?? "";
            decimal preco = LerDecimal("Preço: ");
            int estoque = LerInteiro("Quantidade em estoque: ");
            catalogo.CadastrarProduto(new Produto(nome, preco, estoque));
            System.Console.WriteLine("Produto cadastrado com sucesso.");
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            System.Console.WriteLine($"Não foi possível cadastrar: {ex.Message}");
        }
        Pausar();
    }

    private static void ExibirCatalogo(Catalogo catalogo)
    {
        System.Console.WriteLine("\n--- CATÁLOGO ---");
        if (catalogo.Produtos.Count == 0)
            System.Console.WriteLine("Nenhum produto cadastrado.");

        foreach (var produto in catalogo.Produtos)
            System.Console.WriteLine(produto);
        Pausar();
    }

    private static void AdicionarAoCarrinho(Catalogo catalogo, CarrinhoDeCompras carrinho)
    {
        try
        {
            System.Console.Write("Nome do produto: ");
            string nome = System.Console.ReadLine() ?? "";
            Produto produto = catalogo.BuscarPorNome(nome)
                ?? throw new InvalidOperationException("Produto não encontrado.");
            int quantidade = LerInteiro("Quantidade: ");
            carrinho.AdicionarProduto(produto, quantidade);
            System.Console.WriteLine("Produto adicionado ao carrinho.");
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            System.Console.WriteLine($"Não foi possível adicionar: {ex.Message}");
        }
        Pausar();
    }

    private static void RemoverDoCarrinho(Catalogo catalogo, CarrinhoDeCompras carrinho)
    {
        try
        {
            System.Console.Write("Nome do produto: ");
            string nome = System.Console.ReadLine() ?? "";
            Produto produto = catalogo.BuscarPorNome(nome)
                ?? throw new InvalidOperationException("Produto não encontrado.");
            int quantidade = LerInteiro("Quantidade a remover: ");
            carrinho.RemoverProduto(produto, quantidade);
            System.Console.WriteLine("Item removido do carrinho.");
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            System.Console.WriteLine($"Não foi possível remover: {ex.Message}");
        }
        Pausar();
    }

    private static void ExibirCarrinho(CarrinhoDeCompras carrinho)
    {
        System.Console.WriteLine("\n--- SEU CARRINHO ---");
        if (carrinho.Itens.Count == 0)
            System.Console.WriteLine("Carrinho vazio.");

        foreach (var item in carrinho.Itens)
        {
            decimal subtotal = item.Produto.Preco * item.Quantidade;
            System.Console.WriteLine($"{item.Produto.Nome} | {item.Quantidade} x {item.Produto.Preco.ToString("C2", Cultura)} = {subtotal.ToString("C2", Cultura)}");
        }

        System.Console.WriteLine($"TOTAL: {carrinho.CalcularSubtotal().ToString("C2", Cultura)}");
        Pausar();
    }

    private static void FinalizarPedido(CarrinhoDeCompras carrinho)
    {
        try
        {
            if (carrinho.Itens.Count == 0)
                throw new InvalidOperationException("Não é possível finalizar um carrinho vazio.");

            var pedido = new Pedido(carrinho);
            pedido.FinalizarCompra();
            System.Console.WriteLine($"Compra finalizada! Total: {pedido.Total.ToString("C2", Cultura)}");
            System.Console.WriteLine("O estoque dos produtos foi atualizado.");
        }
        catch (InvalidOperationException ex)
        {
            System.Console.WriteLine($"Não foi possível finalizar o pedido: {ex.Message}");
            Pausar();
        }
    }

    private static int LerInteiro(string mensagem)
    {
        while (true)
        {
            System.Console.Write(mensagem);
            if (int.TryParse(System.Console.ReadLine(), out int valor))
                return valor;
            System.Console.WriteLine("Digite um número inteiro válido.");
        }
    }

    private static decimal LerDecimal(string mensagem)
    {
        while (true)
        {
            System.Console.Write(mensagem);
            string entrada = System.Console.ReadLine() ?? "";
            if (decimal.TryParse(entrada, NumberStyles.Number, Cultura, out decimal valor))
                return valor;
            System.Console.WriteLine("Digite um preço válido. Exemplo: 49,90");
        }
    }

    private static void Pausar()
    {
        System.Console.WriteLine("\nPressione ENTER para continuar...");
        System.Console.ReadLine();
    }
}
