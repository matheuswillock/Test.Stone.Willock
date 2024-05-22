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

## Conclus�o

Este projeto foi desenvolvido como parte do desafio t�cnico da Stone. Ele demonstra o uso de v�rias tecnologias, incluindo C#, .NET, Entity Framework Core, FluentValidation, Docker Compose e Swagger, para criar uma aplica��o robusta e bem estruturada.

Espero que as informa��es fornecidas neste README sejam �teis para entender a estrutura e as tecnologias utilizadas no projeto. Se voc� tiver alguma d�vida ou precisar de mais informa��es, n�o hesite em entrar em contato comigo.

Obrigado por dedicar seu tempo para revisar este projeto!
