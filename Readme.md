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

## Conclusão

Este projeto foi desenvolvido como parte do desafio técnico da Stone. Ele demonstra o uso de várias tecnologias, incluindo C#, .NET, Entity Framework Core, FluentValidation, Docker Compose e Swagger, para criar uma aplicação robusta e bem estruturada.

Espero que as informações fornecidas neste README sejam úteis para entender a estrutura e as tecnologias utilizadas no projeto. Se você tiver alguma dúvida ou precisar de mais informações, não hesite em entrar em contato comigo.

Obrigado por dedicar seu tempo para revisar este projeto!
