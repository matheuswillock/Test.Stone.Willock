# Desafio Técnico - Stone
Olá! <img width=30px height=30px src="https://raw.githubusercontent.com/kaueMarques/kaueMarques/master/hi.gif"/>

Este é o meu projeto para o desafio técnico da Stone. Abaixo estão as instruções para executar o projeto localmente e uma breve explicação sobre a estrutura.

### Pré-requisitos
Para executar este projeto, você precisará ter as seguintes ferramentas instaladas:
- Entity Framework (instalado globalmente)
- .NET Core 8.0

### Instruções de Execução
Para executar este projeto localmente, siga os passos abaixo:

1. Clone o repositório:
```shell
git clone https://github.com/matheuswillock/Test.Stone.Willock.git
```

2. Acesse o diretório do projeto:
```shell
cd Test.Stone.Willock
```

3. Execute o Docker Compose para configurar o banco de dados
```shell
docker-compose up -d
```

4. Caso queira acessar o banco de dados com um Client de sua preferência segue a abaixo as infos:
```shell
Host: localhost
Port: 5432
Database: stone_db_postgres
Username: my_user
Password: my_pw
```

5. Instale as dependências e xecute o build do projeto:
```shell
dotnet build

dotnet restore
```

6. Atualize o banco de dados:
```shell
cd Test.Stone.Willock.WebApi

dotnet ef database update
```

7. Execute o projeto:
```shell
dotnet run
```

## Estrutura do Projeto

O projeto está estruturado da seguinte forma:

- **Application**: Contém as use cases e suas DTOs de input e output. Também inclui a biblioteca com a classe Output, usada na comunicação entre as classes que trafegam informações.
- **Domain**: Contém as entidades do projeto e enums.
- **Infrastructure**: Contém a persistência no banco de dados Postgres.
- **WebApi**: Contém as controllers e validators.

## Tecnologias Utilizadas

* **C#**: Linguagem de programação principal.
* **.NET**: Framework utilizado para o desenvolvimento do aplicativo.
* **Entity Framework Core**: ORM utilizado para acessar o banco de dados.
* **FluentValidation**: Biblioteca utilizada para validação de dados.
* **Docker Compose**: Utilizado para configurar o banco de dados Postgres.
* **Swagger**: Utilizado para documentar a API.

# Contato

Se você tiver alguma dúvida ou precisar de mais informações, não hesite em entrar em contato comigo.

Obrigado!