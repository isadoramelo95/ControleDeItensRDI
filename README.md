CodeRDIVersity

O banco de dados foi criado e configurado utilizando as migrations do Entity Framework.
As migrations são aplicadas automaticamente ao executar `dotnet ef database update`.

Configure a string de conexão no arquivo `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=LAPTOP-UC5IQEQ6;Database=GeladeiraMigration;Uid=sa;Pwd=123;Trusted_Connection=True;TrustServerCertificate=True;"
}

### Endpoints da API

- `GET /api/ListaItens`: Retorna a lista de itens.
- `POST /api/AddLista`: Adiciona a lista de itens.
- `POST /api/AdicionarItem`: Adiciona um novo item.
- `PUT /api/AtualizarItem`: Altera um item.
- `DELETE /api/RemoverPorId`: Remove um item pelo ID.

Banco de Dados
select * from [dbo].[Items]

![image](https://github.com/user-attachments/assets/fbb380a7-e6e2-424d-a33d-b65c26ce34b6)
