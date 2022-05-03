# VxTel

# Backend
  
  A solução Backend foi desenvolvida utilizando .Net Core 6, com o EnityFramework para criação e manipulação do banco de dados utilizado foi o SqlServer e foi dividido em 5 projetos
  
  
  1. VxTel.Api  
  2. VxTel.Core
  3. VxTel.EntityFramework
  4. VxTel.Shared
  5. VxTel.Tests
  
  
  VxTel.Api ->
    Reponsavel pelo gerenciamento de Controllers da API e Profiles para mapeamento de objetos em Dtos
    
  VxTel.Core ->
    Projeto responsável pelo fluxo de dados entre o banco de dados e outras aplicações do projeto. Os Domains estão neste projeto.
    
  VxTel.EntityFramework ->
    Projeto com o Contexto, Migrations e Seeds utilizados para controle do banco de dados
    
  VxTel.Shared ->
    Projeto com Objetos e Dtos utilizados
    
  VxTel.Tests ->
    Projeto Responsável pelos testes de validação dos Domains
    
    
  Para criação do banco de dados, é necessário alterar a string de conexão presente em dois arquivos
  
    1. VxTel.Api > appsettings.json
      Alterar a string de conexão "Default"
      "ConnectionStrings": {
        "Default": "Server=localhost;Initial Catalog=VxTelDb;Trusted_Connection=True"
      },
      
    2. VxTel.EntityFramework > VxTelDbContext 
      Alterar para a mesma string de conexão do passo anterior
      options.UseSqlServer("Server=localhost;Initial Catalog=VxTelDb;Trusted_Connection=True");
    
    Após alterar a string de conexão em ambos arquivos, basta executar o comando "update-database" no Console do Gerenciador de Pacotes do VS,
    utilizando o projeto padrão e o projeto de inicialização "VxTel.Api"
    ![image](https://user-images.githubusercontent.com/63166456/166400220-cdc1ddbb-7bd8-4f19-93f4-d8f8c1119f7f.png)
    ![image](https://user-images.githubusercontent.com/63166456/166400107-cc674de9-83d0-441c-837a-ffd1b2027201.png)

  
  
  
    
  
# Frontend
