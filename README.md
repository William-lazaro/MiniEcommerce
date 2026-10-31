# MiniEcommerce

Aplicação de console desenvolvida em C# com .NET 10 para a atividade de Garantia da Qualidade de Software.

## Funcionalidades
- Cadastro de produtos com validação de nome, preço e estoque.
- Catálogo com consulta por nome e listagem de produtos disponíveis.
- Carrinho com adição e remoção parcial ou total de itens.
- Verificação de estoque antes de adicionar e finalizar a compra.
- Checkout com cálculo do total e baixa automática no estoque.
- Tratamento de entradas inválidas no menu de console.
- Testes unitários com xUnit.

## Estrutura
- `MiniEcommerce.Console`: aplicação e regras de negócio.
- `MiniEcommerce.Tests`: testes automatizados.
- `Produto.cs`: entidade e regras de estoque.
- `Catalogo.cs`: cadastro, busca e listagem.
- `CarrinhoDeCompras.cs`: gerenciamento dos itens e subtotal.
- `Pedido.cs`: finalização e totalização do pedido.
- `Program.cs`: menu de interação pelo terminal.

## Requisitos
- SDK .NET 10 instalado.

## Executar
Na pasta que contém `MiniEcommerce.slnx`:

```bash
dotnet restore
dotnet run --project MiniEcommerce.Console/MiniEcommerce.Console.csproj
```

## Executar os testes

```bash
dotnet test
```

## Cobertura de testes

```bash
dotnet test --collect:"XPlat Code Coverage"
```

A cobertura mede quais partes do código foram executadas durante os testes; não comprova ausência de defeitos.

## Observação
Os produtos de exemplo são carregados em memória quando a aplicação inicia. Os dados não são persistidos após encerrar o programa.
