# Empresa Consultador

API deste projeto foi um desafio passado pelo grupo GPS, onde o objetivo era consumir a API de um terceiro (Receita Ws) com o CNPJ da empresa procurada após isto o usuário poderia escolher salvar os dados retornados no banco de dados da aplicação, onde foi utilizado a biblioteca Entity Framework Core e o banco de dados SQL Server.


# Preparando o ambiente de desenvolvimento

Selecione **Cnpj.Api** como executador principal da solução, logo após abra o **Package Manager Console**, selecione **Cnpj.Data** em **Defaut Projcet** e execute o código "update-database -Verbose -Context ApiDbContext", após os passos anteriores basta apenas executar o ambiente de desenvolvimento para testar a API.
