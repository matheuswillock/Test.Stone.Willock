# Desafio T�cnico - Stone
Ol�! <img width=30px height=30px src="https://raw.githubusercontent.com/kaueMarques/kaueMarques/master/hi.gif"/>

Este � o meu projeto para o desafio t�cnico da Stone. Abaixo est�o as instru��es para executar o projeto localmente e uma breve explica��o sobre a estrutura.

### Pr�-requisitos
Para executar este projeto, voc� precisar� ter as seguintes ferramentas instaladas:
- Entity Framework (instalado globalmente)
- .NET Core 8.0

### Instru��es de Execu��o
Para executar este projeto localmente, siga os passos abaixo:

1. Clone o reposit�rio:
```shell
git clone https://github.com/matheuswillock/Test.Stone.Willock.git
```

2. Acesse o diret�rio do projeto:
```shell
cd Test.Stone.Willock
```

3. Execute o Docker Compose para configurar o banco de dados
```shell
docker-compose up -d
```

4. Caso queira acessar o banco de dados com um Client de sua prefer�ncia segue a abaixo as infos:
```shell
Host: localhost
Port: 5432
Database: stone_db_postgres
Username: my_user
Password: my_pw
```

5. Instale as depend�ncias e xecute o build do projeto:
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