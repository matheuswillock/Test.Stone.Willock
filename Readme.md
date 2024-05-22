# Desafio Técnico - Stone
Olá! <img width=30px height=30px src="https://raw.githubusercontent.com/kaueMarques/kaueMarques/master/hi.gif"/>

Este é o meu projeto para o desafio técnico da Stone. Abaixo estão as instruções para executar o projeto localmente e uma breve explicação sobre a estrutura.

Instruções de Execução
Para executar este projeto localmente, siga os passos abaixo:

1. Clone o repositório:

```shell
git clone https://github.com/matheuswillock/Teste.Tecnico.Stone.Willock.git
```
2. Acesse o diretório do projeto:

```shell
cd Teste.Tecnico.Stone.Willock
```
3. Execute o Docker Compose para configurar o banco de dados
```shell
docker-compose up -d
```
4. Acesse o banco de dados para verificar a criação das tabelas:

```shell
Host: localhost
Port: 5432
Database: stone_db_postgres
Username: my_user
Password: my_pw
```

5. Instale as dependências:

```shell
dotnet restore
```

6. Execute o projeto:

```shell
cd Teste.Tecnico.Stone.Willock.WebApi
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