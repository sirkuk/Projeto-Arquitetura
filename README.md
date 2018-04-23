# Projeto-Contas

Passos para rodar o projeto API (CRUD):
1. No projeto "HubFintech.Infra.Data.SQLServer" localizado na pasta "5.Infra" da solução consta o arquivo scripts.sql no qual estão a
criação do Banco de dados (SQL Server 2014);
2. O projeto "HubFintech.Service.ContaAPI" localizado na pasta "2.Service" é o projeto que deve ser rodado, o projeto Web API. Constam nele
as chamadas API;
3. Um exemplo para consumir uma chamada API com parametro "frombody":
  - {host}/api/conta/contacliente método POST;
  - application/json para HEADER;
  - Body JSON:
  {
    "Id":0,
    "ContaPaiId":null,
    "Matriz":true,
    "Nome":"Teste Conta 1",
    "Cliente":{
      "Id":0,
      "DataNascimento":"1986-12-15T00:00:00",
      "DataCadastro":"0001-01-01T00:00:00",
      "Cpf":"34252533368",
      "NomeCompleto":"Beltrano Silva",
      "Cnpj":null,"Razaosocial":null,"NomeFantasia":null,"ValidationResult":null},
    "Status":1,
    "DataCriacao":"0001-01-01T00:00:00",
    "ValidationResult":null
    }
