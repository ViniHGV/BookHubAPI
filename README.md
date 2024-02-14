# 📚 BookHub API

## 📋Descrição

- A BookHub API é uma plataforma robusta e altamente escalável desenvolvida em Django com Python, projetada para gerenciar uma biblioteca completa, incluindo livros, autores e categorias. A API segue os princípios SOLID e oferece uma ampla gama de funcionalidades para atender às necessidades de uma biblioteca moderna.

## 🚀 Funcionalidades Adicionadas

### Livros

- [x] Listar todos os livros disponíveis na biblioteca com páginação.
- [x] Obter informações detalhadas de um livro específico por ID.
- [x] Adicionar novos livros à biblioteca.
- [x] Atualizar informações de livros existentes.
- [x] Remover livros da biblioteca.

### Autores

- [x] Listar todos os autores cadastrados com páginação.
- [x] Visualizar detalhes de um autor específico por ID e visualizar livros do autor com páginação.
- [x] Atualizar informações de autores existentes.
- [x] Excluir autores do sistema.

### Categorias

- [x] Listar todas as categorias disponíveis com páginação.
- [x] Visualizar detalhes de uma categoria específica por ID e visualizar livros da categoria com páginação.
- [x] Adicionar novas categorias.
- [x] Atualizar informações de categorias existentes.
- [x] Remover categorias da lista.

### ↔ Relacionamentos

- [x] Cada livro está associado a um único autor e a uma única categoria.
- [x] Um autor pode ter escrito vários livros.
- [x] Uma categoria pode conter vários livros.

## 🎲 Desafios Adicionais

### Além das funcionalidades básicas, a BookHub API inclui desafios adicionais para torná-la ainda mais impressionante:

- [x] Implementação de paginação para otimizar a performance dos endpoints de listagem.
- Capacidade de filtrar livros por autor, categoria, ano de publicação ou ISBN.
- Adição de um endpoint para buscar livros por similaridade, baseado em título, autor ou categoria.
- Implementação de autenticação e autorização para garantir a segurança dos endpoints da API.
- [x] Geração automática de documentação utilizando Swagger.

## 💻 Recursos e Tecnologias Utilizadas

- ASP.NET: Framework web da Microsoft para desenvolvimento de aplicativos web robustos.
- C#: Linguagem de programação orientada a objetos utilizada para desenvolvimento de aplicativos .NET.
- SOLID: Princípios de design de software que garantem código limpo, sustentável e de fácil manutenção.

## Como Utilizar

- Clone o repositório do projeto para sua máquina local.

```bash
  git clone https://github.com/ViniHGV/BookHubAPI.git
  cd BookHubAPI
```

- Configure o ambiente virtual .NET e instale as dependências necessárias.

```bash
   dotnet build
```

- Execute as migrações no banco de dados PostgreSQL com o EntityFramework para criar as tabelas ou atributos necessários.

```bash
   dotnet ef migrations add NomeDaMigração
```

- Inicie o servidor ASP.NET e acesse a API por meio dos endpoints fornecidos por meio do Swagger.

```bash
   dotnet watch run
```

## Contribuições

- Contribuições são bem-vindas! Sinta-se à vontade para enviar pull requests com novos recursos, correções de bugs ou melhorias na documentação.

## Autor

- Este projeto foi desenvolvido por ViniHGV, e faz parte de uma demonstração de habilidades em desenvolvimento web com ASP.NET e .NET C#.

## Licença

- Este projeto está licenciado sob a Licença MIT.
