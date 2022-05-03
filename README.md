# VxTel

# Backend
  
  A solução Backend foi desenvolvida utilizando .Net Core 6, com o EnityFramework para criação e manipulação do banco de dados utilizado foi o SqlServer e foi dividido em 5 projetos
  
  
  1. VxTel.Api  ->
    Reponsavel pelo gerenciamento de Controllers da API e Profiles para mapeamento de objetos em Dtos
  2. VxTel.Core ->
    Projeto responsável pelo fluxo de dados entre o banco de dados e outras aplicações do projeto. Os Domains estão neste projeto.
  3. VxTel.EntityFramework ->
    Projeto com o Contexto, Migrations  para controle do banco de dados e dados iniciais ( disponiveis na pasta Seeds ) a serem inseridos no banco
  4. VxTel.Shared  ->
    Projeto com Objetos e Dtos utilizados
  5. VxTel.Tests ->
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

Para execução da API, após criação do banco de dados, é necessário executar o projeto VxTel.Api. Será aberto o Swagger do projeto, com os endpoints disponiveis
  
  
Foram criados apenas dois objetos no banco de dados, CallPlan e CallPrice
	1. CallPlan são os planos disponiveis pela VxTel
	2. CallPrices são os possiveis DDD origem e destino e preço por minuto de cada ligação

O Projeto VxTel.Core possui 3 Dominios
	1. CallPlanDomain, para fluxo de dados com a tabela CallPlans
	2. CallPriceDomain, para fluxo de dados com a tabela CallPrices
	3. ComparePriceDomain, para realização de calculos de comparação de preço com e sem o plano, conforme o especificado no projeto
	
O projeto VxTel.Api possui 3 controllers, cada um com apenas um endpoint
  1. CallPlanController -> Endpoint GetAllPlans, retorna um Dto com uma lista de todos CallPlan disponiveis
  2. CallPriceController -> Endpoint GetAllPlans, retorna um Dto com uma lista de todos CallPlan disponiveis
  3. CallPlanController -> Endpoint PostCallCompare, objeto com informações necessárias para exibir ao cliente os dados de comparação entre com e sem o plano
 
Para mapeamento entre o objeto de entidade e o Dto foi utilizado a lib AutoMapper, e os mapeamentos estão disponiveis na paste Profiles no projeto VxTel.Api

Para os testes, foram criados três arquivos
	1. ComparePriceTests -> Afim de garantir que os cálculos realizados pelo ComparePriceDomain seguem conforme o especificado
	2. PlanTests -> Afim de garantir que os Seeds foram criados, assim como testar a inserção de um novo plano de dados da VxTel de forma correta no banco de dados
	3. PriceTests -> Afim de garantir que os Seeds foram criados, assim como testar a inserção de um nova origem e destino de ligações ofertadas pela VxTel e garantir que a modelagem de dados não permita dois registros possiveis para uma mesma origem e destino
	
# Frontend

O Projeto do Frontend está disponivel na mesma pasta do projeto do Backend com o nome "vxtel-react"

O Frontend foi desenvolvido utilizando a linguagem ReactJS e a lib MUI

Para execução do projeto, basta executar o comando "npm start"

Na pagina são exibidas duas tabelas, com dados da API anteriormente descrita, uma com preços de origem e destino e outra com os planos disponibilizados pela VxTel

![image](https://user-images.githubusercontent.com/63166456/166401536-7f711083-3fda-423d-afbb-594008c797f5.png)

![image](https://user-images.githubusercontent.com/63166456/166401542-7236e7fd-8f44-43db-ac36-407756fa05c6.png)

No fim da pagina, há como o usuário utilizar os inputs fornecidos para comparar o gasto mensal com e sem algum plano oferecido pela VxTel

![image](https://user-images.githubusercontent.com/63166456/166401456-11693ea7-cd90-4409-a206-8ae6e416cd0b.png)

![image](https://user-images.githubusercontent.com/63166456/166401518-a6115268-f615-4b6a-8eb4-deaab63b5ee4.png)




