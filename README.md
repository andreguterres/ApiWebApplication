
Métodos desenvolvidos WEb API ASP NET CORE 7.

foram utilizados seguintes comandos para gerar scrip de banco pelo Migration:

dotnet ef migrations add inicial --project WebApi

dotnet ef database update --project WebApi -s WebApi --verbose

O upload do arquivo tem entrada public IFormFile LogoTipoFile { get; set; }, e é convertido para public byte[]? LogoTipo { get; set; }, para que seja salvo no banco sqlserver.
Foram implementados métos de Adicionar, Atualizar, PesqisaId, Pesquisar e Deletar.

Métotodo Adicionar inclui um Cliente com uma lista de logradouros. Segue o json esperado. 
{
  "clienteId": 0,
  "nome": "string",
  "email": "string",
  "logoTipoFile": "string",
  "logoTipo": "string",
  "logradouros": [
    {
      "logradouroId": 0,
      "nomeRua": "string",
      "numero": "string",
      "bairro": "string"
    }
  ]
}

Retornado 200.

Métotodo Pesquisar, lista dodos clientes cadastrados, não necessita a entrada de parametros.

retornando 200
[
  {
    "clienteId": 0,
    "nome": "string",
    "email": "string",
    "logoTipoFile": "string",
    "logoTipo": "string",
    "logradouros": [
      {
        "logradouroId": 0,
        "nomeRua": "string",
        "numero": "string",
        "bairro": "string"
      }
    ]
  }
]

Métotodo PesquisarId consulta cliente pelo id(int) de campo obrigatório.

Resposta 200:
[
  {
    "clienteId": 0,
    "nome": "string",
    "email": "string",
    "logoTipoFile": "string",
    "logoTipo": "string",
    "logradouros": [
      {
        "logradouroId": 0,
        "nomeRua": "string",
        "numero": "string",
        "bairro": "string"
      }
    ]
  }
]

Retornado [] quando vazio.

Métotodo Delete atualiza um Cliente com uma lista de logradouros.

Resposta 200

[
  {
    "clienteId": 0,
    "nome": "string",
    "email": "string",
    "logoTipoFile": "string",
    "logoTipo": "string",
    "logradouros": [
      {
        "logradouroId": 0,
        "nomeRua": "string",
        "numero": "string",
        "bairro": "string"
      }
    ]
  }
]








