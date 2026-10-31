🛒 MiniEcommerce

Sistema de gerenciamento de produtos, carrinho de compras e pedidos desenvolvido em C# com .NET 10.

"C#" (https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
".NET" (https://img.shields.io/badge/.NET%2010-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
"xUnit" (https://img.shields.io/badge/Testes-xUnit-228B22?style=for-the-badge)
"Git" (https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)

📖 Sobre o projeto

O MiniEcommerce é uma aplicação de console desenvolvida em C# e .NET 10, como parte das atividades acadêmicas da disciplina de Garantia da Qualidade de Software.

O projeto simula o funcionamento básico de um comércio eletrônico, permitindo cadastrar produtos, consultar o catálogo, gerenciar um carrinho de compras e finalizar pedidos com atualização automática do estoque.

Seu desenvolvimento tem como foco a aplicação de conceitos de Programação Orientada a Objetos (POO), organização de código, validação de regras de negócio e testes automatizados.

🚀 Funcionalidades

📦 Gerenciamento de produtos

- Cadastro de produtos com nome, preço e quantidade em estoque.
- Validação de informações obrigatórias.
- Impedimento de preços e estoques negativos.
- Controle da quantidade disponível de cada produto.

📋 Catálogo de produtos

- Listagem dos produtos cadastrados.
- Consulta de produtos pelo nome.
- Visualização de preços e disponibilidade em estoque.

🛒 Carrinho de compras

- Adição de produtos ao carrinho.
- Remoção parcial ou total de itens.
- Controle das quantidades selecionadas.
- Cálculo automático do subtotal.
- Verificação de estoque disponível.

💳 Finalização de pedidos

- Validação do estoque antes da finalização.
- Cálculo do valor total da compra.
- Atualização automática do estoque após a confirmação.
- Organização das informações do pedido.

🖥️ Interface de console

- Menu interativo para utilização das funcionalidades.
- Tratamento de entradas inválidas.
- Mensagens de orientação e validação para o usuário.

🛠️ Tecnologias utilizadas

Tecnologia| Finalidade
C#| Desenvolvimento da aplicação e das regras de negócio
.NET 10| Plataforma de execução
xUnit| Testes unitários automatizados
Git| Controle de versão
GitHub| Hospedagem e colaboração no código
Visual Studio Code| Ambiente de desenvolvimento

📂 Estrutura do projeto

MiniEcommerce/
│
├── MiniEcommerce.Console/
│   ├── Produto.cs
│   ├── Catalogo.cs
│   ├── CarrinhoDeCompras.cs
│   ├── Pedido.cs
│   └── Program.cs
│
├── MiniEcommerce.Tests/
│   └── Testes automatizados com xUnit
│
├── MiniEcommerce.slnx
└── README.md

Responsabilidades dos principais componentes:

- "Produto.cs" — Representa os produtos e gerencia regras relacionadas ao estoque.
- "Catalogo.cs" — Responsável pelo cadastro, consulta e listagem dos produtos.
- "CarrinhoDeCompras.cs" — Gerencia os itens selecionados e calcula o subtotal.
- "Pedido.cs" — Responsável pela finalização e totalização das compras.
- "Program.cs" — Contém o menu interativo da aplicação.

⚙️ Instalação e execução

Pré-requisitos

Para executar o projeto, é necessário ter instalado:

- ".NET SDK 10" (https://dotnet.microsoft.com/download/dotnet/10)
- "Git" (https://git-scm.com/downloads)
- "Visual Studio Code" (https://code.visualstudio.com/) (opcional)

1. Clonar o repositório

Abra o terminal e execute:

git clone https://github.com/GabrielGobira/MiniEcommerce.git

2. Acessar a pasta do projeto

cd MiniEcommerce

3. Restaurar as dependências

dotnet restore

4. Compilar o projeto

dotnet build

5. Executar a aplicação

dotnet run --project MiniEcommerce.Console/MiniEcommerce.Console.csproj

Após a execução, o menu interativo será apresentado no terminal, permitindo utilizar as funcionalidades do sistema.

🧪 Testes automatizados

O projeto utiliza o framework xUnit para verificar o comportamento das funcionalidades e das regras de negócio.

Os testes ajudam a identificar comportamentos inesperados e a reduzir o risco de regressões durante o desenvolvimento.

Executar todos os testes

Na pasta principal do projeto, execute:

dotnet test

Executar os testes com mais detalhes

dotnet test --verbosity normal

Executar com coleta de cobertura

dotnet test --collect:"XPlat Code Coverage"

O comando de cobertura requer que o coletor "coverlet.collector" esteja configurado no projeto de testes.

A cobertura indica quais partes do código foram exercitadas durante a execução dos testes. Entretanto, uma cobertura elevada não garante a ausência de defeitos.

🧠 Conceitos aplicados

Durante o desenvolvimento, foram trabalhados conceitos importantes de engenharia e qualidade de software:

- Programação Orientada a Objetos: organização do sistema em classes com responsabilidades específicas.
- Encapsulamento: controle do acesso e das alterações aos dados.
- Regras de negócio: validação das operações de cadastro, estoque e compra.
- Tratamento de exceções: prevenção e gerenciamento de operações inválidas.
- Testes unitários: verificação automatizada do comportamento do sistema.
- Separação de responsabilidades: organização do código para facilitar a manutenção.
- Versionamento: acompanhamento das alterações realizadas no projeto com Git e GitHub.

💾 Armazenamento de dados

O MiniEcommerce utiliza armazenamento em memória.

Os produtos de exemplo são carregados automaticamente quando a aplicação é iniciada.

Importante: os dados não são persistidos. Ao encerrar o programa, as alterações realizadas durante a execução são perdidas.

Uma possível evolução futura é a integração com um banco de dados para armazenamento permanente das informações.

🔮 Possíveis melhorias futuras

- Integração com banco de dados SQLite ou SQL Server.
- Persistência de produtos, pedidos e histórico de compras.
- Cadastro e autenticação de usuários.
- Interface gráfica ou aplicação web.
- Desenvolvimento de uma API REST.
- Implementação de integração contínua com GitHub Actions.

🎓 Objetivo acadêmico

O projeto foi desenvolvido com finalidade educacional, buscando consolidar conhecimentos em desenvolvimento de software e demonstrar, na prática, a importância dos testes automatizados e da validação das regras de negócio.

👨‍💻 Repositório e contribuições

Gabriel Gobira 
Marcela Anataniel 
Nathaly Caroline 
William Lázaro 



⭐ MiniEcommerce — Aprendizado prático em C#, .NET e qualidade de software.