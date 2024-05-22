# Desafio T�cnico - Stone
Ol�! <img width=30px height=30px src="https://raw.githubusercontent.com/kaueMarques/kaueMarques/master/hi.gif"/>

Este � o meu projeto para o desafio t�cnico da Stone. Abaixo est�o as instru��es para executar o projeto localmente e uma breve explica��o sobre a estrutura.

Instru��es de Execu��o
Para executar este projeto localmente, siga os passos abaixo:

1. Clone o reposit�rio:

```shell
git clone https://github.com/matheuswillock/Teste.Tecnico.Stone.Willock.git
```
2. Acesse o diret�rio do projeto:

```shell
cd Teste.Tecnico.Stone.Willock
```
3. Execute o Docker Compose para configurar o banco de dados
```shell
docker-compose up -d
```
4. Acesse o banco de dados para verificar a cria��o das tabelas:

```shell
Host: localhost
Port: 5432
Database: stone_db_postgres
Username: my_user
Password: my_pw
```

5. Instale as depend�ncias:

```shell
dotnet restore
```

6. Execute o projeto:

```shell
cd Teste.Tecnico.Stone.Willock.WebApi
dotnet run
```

## Estrutura do Projeto

O projeto est� estruturado da seguinte forma:

- **Application**: Cont�m as use cases e suas DTOs de input e output. Tamb�m inclui a biblioteca com a classe Output, usada na comunica��o entre as classes que trafegam informa��es.
- **Domain**: Cont�m as entidades do projeto e enums.
- **Infrastructure**: Cont�m a persist�ncia no banco de dados Postgres.
- **WebApi**: Cont�m as controllers e validators.

## Tecnologias Utilizadas

* **C#**: Linguagem de programa��o principal.
* **.NET**: Framework utilizado para o desenvolvimento do aplicativo.
* **Entity Framework Core**: ORM utilizado para acessar o banco de dados.
* **FluentValidation**: Biblioteca utilizada para valida��o de dados.
* **Docker Compose**: Utilizado para configurar o banco de dados Postgres.
* **Swagger**: Utilizado para documentar a API.

# Contato

Se voc� tiver alguma d�vida ou precisar de mais informa��es, n�o hesite em entrar em contato comigo.

Obrigado!