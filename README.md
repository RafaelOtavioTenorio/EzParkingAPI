# EzParkingAPI 🚗
API Backend para o sistema de controle de acesso a estacionamentos.

## 📌 Sobre o Projeto
EzParkingAPI é a API backend responsável por fornecer todos os serviços do sistema EzParking. Ela gerencia a autenticação de usuários, o cadastro de veículos e o controle das vagas de estacionamento, oferecendo uma interface RESTful para comunicação com o frontend.

## 🚀 Tecnologias Utilizadas
- C# com .NET 6: Para a criação da API.
- Entity Framework Core: Para interagir com o banco de dados.
- SQL Server: Para armazenamento de dados.
- Swagger: Para documentação interativa da API.
- JWT: Para autenticação e segurança.

##📂 Como Rodar o Projeto
###1. Clonar o Repositório
Clone o repositório do backend:
```bash
git clone -b develop https://github.com/RafaelOtavioTenorio/EzParkingAPI.git
```

2. Configurar o Backend (.NET 6 API)
Navegue para a pasta do backend:
```bash
cd EzParkingAPI
```

Restaurar dependências:
```bash
dotnet restore
```

Rodar as migrações para criar o banco de dados:
```bash
# Certifique-se de configurar a string de conexão no appsettings.json
dotnet ef database update
```

Rodar o servidor:
```bash
dotnet run
```
A API estará rodando em `http://localhost:5000`.

3. Acessar a Documentação (Swagger)
A documentação da API estará disponível em http://localhost:5000/swagger após rodar a API. Isso permite testar as rotas diretamente no navegador.

📌 Endpoints Importantes
- **POST** `/api/auth/login`: Autenticação de usuário.
- **POST** `/api/users/register`: Registro de novo usuário.
- **GET** `/api/vehicles`: Consulta de veículos cadastrados.
- **POST** `/api/vehicles`: Cadastro de novo veículo.
- **GET** `/api/parking/spots`: Consulta de vagas de estacionamento.

📌 Status do Projeto
✅ Estrutura inicial da API criada  
✅ API de autenticação configurada  
✅ CRUD de usuários funcional  
🔧 Em desenvolvimento: Cadastro e controle de veículos  
🛠 Planejado: Consulta de vagas em tempo real  

📜 Roadmap e Contribuição
Se quiser acompanhar o desenvolvimento ou contribuir, verifique a aba **Issues** e **Projects** aqui no GitHub.

📌 Autor
**Rafael Otávio Tenório**  
[LinkedIn](https://www.linkedin.com/in/rafael-otavio-tenorio/)
