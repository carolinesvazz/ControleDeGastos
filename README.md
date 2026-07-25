# 💰 Controle de Gastos Residenciais

Sistema Full Stack para gerenciamento de gastos residenciais, desenvolvido como solução para um teste técnico.

A aplicação permite cadastrar pessoas, registrar receitas e despesas, visualizar indicadores financeiros e consultar os totais individuais e gerais, seguindo todas as regras de negócio propostas no desafio.

---

## 📸 Demonstração BackEnd

<img width="616" height="796" alt="image" src="https://github.com/user-attachments/assets/800f7669-994d-456d-85aa-db7a590dcdf4" />

### Login

<img width="1391" height="511" alt="image" src="https://github.com/user-attachments/assets/565e2b99-966a-4308-9b36-b97c5a9a85f3" />


### Dashboard

<img width="1058" height="691" alt="image" src="https://github.com/user-attachments/assets/7b5cd6e6-4aff-470e-9996-3d23319b4cd9" />

### Cadastro de Pessoas

<img width="1401" height="786" alt="image" src="https://github.com/user-attachments/assets/8128652c-1f3c-4f92-81d9-16326194e71f" />


### Cadastro de Transações

<img width="1416" height="634" alt="image" src="https://github.com/user-attachments/assets/4dde9f9d-010b-4c6a-99be-71a4076e43dd" />


### Consulta de Totais

<img width="1062" height="858" alt="image" src="https://github.com/user-attachments/assets/4dd71d46-9278-4be4-a2b1-5b6d9c6d3b32" />


---

# 🚀 Tecnologias utilizadas

## Backend

- .NET 8
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- JWT Authentication

## Frontend

- React
- JavaScript
- React Router
- Axios
- CSS

---

# 📋 Funcionalidades

### Pessoas

- Cadastro de pessoas
- Listagem de pessoas
- Exclusão de pessoas

### Transações

- Cadastro de receitas
- Cadastro de despesas
- Listagem de transações

### Dashboard

- Total de pessoas cadastradas
- Total de transações
- Total de receitas
- Total de despesas
- Saldo geral

### Consulta de Totais

Para cada pessoa são exibidos:

- Total de receitas
- Total de despesas
- Saldo

Ao final da página são apresentados:

- Total geral de receitas
- Total geral de despesas
- Saldo líquido

---

# 📌 Regras de negócio implementadas

- Cada pessoa possui um identificador único gerado automaticamente.
- O identificador informado na transação deve existir no cadastro de pessoas.
- Pessoas menores de 18 anos podem cadastrar apenas despesas.
- Ao excluir uma pessoa, todas as suas transações são removidas automaticamente.
- Os dados permanecem armazenados utilizando SQLite.

---

# 🔐 Autenticação

Foi implementada autenticação utilizando JWT como funcionalidade adicional.

Para acessar a aplicação utilize:

**Email**

```text
admin@email.com
```

**Senha**

```text
123456
```

---

# ⚙️ Como executar o projeto

## Clonar o repositório

```bash
git clone https://github.com/carolinesvazz/ControleDeGastos.git
```

---

## Backend

```bash
cd Backend
```

Instale as dependências:

```bash
dotnet restore
```

Execute a aplicação:

```bash
dotnet run
```

A API será iniciada em:

```text
https://localhost:xxxx
```

---

## Frontend

```bash
cd Frontend
```

Instale as dependências:

```bash
npm install
```

Execute o projeto:

```bash
npm run dev
```

A aplicação ficará disponível em:

```text
http://localhost:5173
```

---

# 📂 Estrutura do projeto

```text
Backend
│
├── Authentication
├── Controllers
├── Data
├── DTOs
├── Migrations
├── Models
└── Services

Frontend
│
├── assets
├── components
├── api
└── pages
```

---

# ✨ Diferenciais

Além dos requisitos propostos no desafio, foram implementados:

- Autenticação utilizando JWT;
- Dashboard com indicadores financeiros;
- Interface responsiva e organizada;
- Arquitetura em camadas;
- Separação entre Controllers, Services, DTOs e Models;
- Organização do Frontend em páginas e camada de consumo da API;
- Código comentado para facilitar a compreensão da lógica implementada.

---

Desenvolvido por **Caroline Vaz**.
