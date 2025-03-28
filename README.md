Este projeto simula o fluxo de pedidos entre Revendas

---

## 🔐 Autenticação

O projeto utiliza autenticação com JWT. Para se autenticar, utilize o endpoint:

```
POST /api/auth/login
```

### 🔐 JSON de autenticação:
```json
{
  "username": "admin",
  "password": "password"
}
```

> Um token JWT será retornado e deverá ser usado no header `Authorization: Bearer {token}` nas demais rotas.

---

## 🗃️ Configurando o banco de dados PostgreSQL

Crie o banco de dados com o nome `RevendaDb`:

```sql
CREATE DATABASE "RevendaDb";
```

No arquivo `appsettings.json`, utilize a connection string abaixo:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=RevendaDb;Username=postgres;Password=password"
}
```

Em seguida, execute os comandos para aplicar as migrations:

```bash
dotnet ef database update
```

---

## 🧠 Padrões e Tecnologias Utilizadas

- ✅ **CQRS (Command Query Responsibility Segregation)** para separar leitura e escrita;
- ✅ **Entity Framework Core** com PostgreSQL para persistência de dados;
- ✅ **MediatR** para orquestração de comandos e queries;
- ✅ **xUnit** + **Moq** para testes unitários;
- ✅ **BackgroundService** para reenvio automático de pedidos em caso de falha;

---

## 🔁 Funcionalidades da API

### 📦 Revendas

| Método | Rota                | Descrição                           |
|--------|---------------------|-------------------------------------|
| POST   | /api/revendas       | Cadastra uma nova revenda           |
| GET    | /api/revendas/{id}  | Consulta uma revenda por ID         |

### 📝 Pedidos

| Método | Rota                              | Descrição                                               |
|--------|-----------------------------------|---------------------------------------------------------|
| POST   | /api/pedidos                      | Cadastra um novo pedido para a revenda                  |
| POST   | /api/pedidos/{id}/enviar-pedidos  | Simula envio do pedido                                  |
| POST   | /api/pedidos/{id}/reenviar        | Reenvia um pedido com falha                             |

---

## 🧪 Testes Unitários

Estão localizados na pasta `/Tests` e cobrem os principais handlers do sistema:

- `CreateRevendaHandlerTests`
- `CreatePedidoHandlerTests`
- `EnviarPedidoHandlerTests`
- `ReenviarPedidoHandlerTests`

### Bibliotecas usadas
- `xUnit` – estrutura de testes
- `Moq` – simulação de dependências
- `Microsoft.EntityFrameworkCore.InMemory` – banco de dados em memória para testes

Execute os testes com:

```bash
dotnet test
```

---

## 🚀 Rodando o projeto

1. Configure sua connection string no `appsettings.json`
2. Rode as migrations: `dotnet ef database update`
3. Inicie a aplicação: `dotnet run`
4. Acesse o Swagger em: `https://localhost:{porta}/swagger`
