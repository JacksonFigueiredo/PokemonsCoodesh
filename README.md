Titulo : PokeApi Master Trainer


Descrição sobre o Projeto

Um sistema para gerenciar mestres Pokémon e capturas de Pokémon usando dados da PokeApi.

Lista com Linguagem, Framework e/ou Tecnologias Usadas

    Linguagem: C#
    Framework: .NET Core
    Banco de Dados: In-memory database
    APIs Externas: PokeApi
    Bibliotecas: Entity Framework Core, Newtonsoft.Json
    Ferramentas: Visual Studio, dotnet CLI

Passos para Instalação

     Clone o repositório:
     git clone [https://github.com/jacksonfigueiredo/pokeapi-master-trainer.git](https://github.com/JacksonFigueiredo/PokemonsCoodesh.git)
     cd pokeapi-master-trainer

Restaure as dependências do projeto: dotnet restore
     Compile o projeto: dotnet build


Passos para Executar o Projeto
     Inicie o projeto: dotnet run --project PokeApi.Presentation

Acesse a API:
     A API estará disponível em https://localhost:5001 ou http://localhost:5000.

Endpoints Disponíveis

Criar um Mestre Pokémon:
        URL: POST /api/master
        Descrição: Cria um novo mestre Pokémon.
        Body:

        json

    {
        "name": "Ash Ketchum",
        "age": 10,
        "cpf": "12345678901"
    }

    Resposta: Retorna os dados do mestre criado.

Capturar um Pokémon:

    URL: POST /api/master/capture
    Descrição: Captura um Pokémon para um mestre específico.
    Body:

    json

    {
        "pokemonId": 25,
        "masterId": 1
    }

    Resposta: Retorna os dados da captura realizada.

Listar Pokémon Capturados:

    URL: GET /api/master/captured
    Descrição: Lista todos os Pokémon capturados pelos mestres.
    Resposta: Retorna uma lista de todos os Pokémon capturados.

Obter 10 Pokémon Aleatórios:

    URL: GET /api/pokemon/random
    Descrição: Retorna 10 Pokémon selecionados aleatoriamente.
    Resposta:

    json

    [
      {
        "id": 1,
        "name": "bulbasaur",
        "baseExperience": 64,
        "spriteBase64": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAA..."
      },
      {
        "id": 4,
        "name": "charmander",
        "baseExperience": 62,
        "spriteBase64": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAA..."
      },
      ...
    ]

Obter Pokémon por Nome:

    URL: GET /api/pokemon/by-name/{name}
    Descrição: Retorna os dados de um Pokémon específico baseado no seu nome.
    Parâmetro de Rota:
        name: O nome do Pokémon a ser buscado.
    Resposta:

    json

    {
        "id": 25,
        "name": "pikachu",
        "baseExperience": 112,
        "spriteBase64": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAA..."
    }

    Status de Resposta: Retorna 404 Not Found se o Pokémon não for encontrado.

    

Obter Pokémon por ID:

    URL: GET /api/pokemon/by-id/{id}
    Descrição: Retorna os dados de um Pokémon específico baseado no seu ID.
    Parâmetro de Rota:
        id: O ID do Pokémon a ser buscado.
    Resposta:

    json

        {
            "id": 25,
            "name": "pikachu",
            "baseExperience": 112,
            "spriteBase64": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAA..."
        }

        Status de Resposta: Retorna 404 Not Found se o Pokémon não for encontrado.

Obter 10 Pokémon Aleatórios:
        Faça uma requisição GET para /api/pokemon/random para receber uma lista de 10 Pokémon aleatórios.
        Exemplo de Requisição:

         curl -X GET "https://localhost:5001/api/pokemon/random"

Obter Pokémon por Nome:

    Faça uma requisição GET para /api/pokemon/by-name/{name}, substituindo {name} pelo nome do Pokémon desejado.
    Exemplo de Requisição:
         
         curl -X GET "https://localhost:5001/api/pokemon/by-name/pikachu"

Obter Pokémon por ID:

    Faça uma requisição GET para /api/pokemon/by-id/{id}, substituindo {id} pelo ID do Pokémon desejado.
    Exemplo de Requisição:

     curl -X GET "https://localhost:5001/api/pokemon/by-id/25"

Challenge by Coodesh
