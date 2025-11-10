# TeemAI Talent – Employee Management (Angular 20 + .NET 8)

A small **Employee Management** web application to demonstrate clean, maintainable CRUD over SQL Server with a modern Angular frontend.

## Objective
Build a simple but robust web app for HR to centrally manage Employees:
- Create, Read, Update, Delete employees
- Search by **Full Name** or **ID**
<img width="1387" height="674" alt="image" src="https://github.com/user-attachments/assets/bf4071c9-1d77-403d-a8ac-c6a25847622e" />

## Stack
- **Frontend:** Angular 20 (standalone components, HttpClient, Forms)
- **Backend:** ASP.NET Core 8 Web API
- **Persistence:** EF Core + SQL Server
- **Tooling:** Swagger/OpenAPI, CORS enabled for local dev

## Repository layout
TeemAITalent.sln  
TeemAITalent.API/             # ASP.NET Core Web API (controllers, DTOs, validation, Swagger)  
TeemAITalent.Application/     # Contracts (e.g., IEmployeeRepository)  
TeemAITalent.Domain/          # Entities (Employee, Department)  
TeemAITalent.Infrastructure/  # EF Core DbContext + repository implementation  
teemai-talent-ui/             # Angular 20 app (standalone)

## Prerequisites
- .NET 8 SDK
- Node 18+ and Angular CLI (`npm i -g @angular/cli`)
- SQL Server LocalDB (or a SQL Server instance / Docker)

---

## Run locally

### 1) Backend (API)
cd TeemAITalent/TeemAITalent.API  
dotnet ef database update  
dotnet run  

# API: http://localhost:5000  (Swagger: http://localhost:5000/swagger)

### 2) Frontend (Angular)
cd ../.. /teemai-talent-ui  
npm install  
ng serve  
# UI: http://localhost:4200

> If needed, update the API CORS policy to allow `http://localhost:4200`.

---

## Quick test (without UI)

# List
curl http://localhost:5000/api/employees

# Create
curl -X POST http://localhost:5000/api/employees ^
  -H "Content-Type: application/json" ^
  -d "{\"fullName\":\"Alice Gomez\",\"hireDate\":\"2024-01-10\",\"position\":\"HR Generalist\",\"salary\":4000,\"department\":\"HR\"}"

---

## API endpoints
- GET  /api/employees?term={nameOrId}   – search by name (LIKE) or exact ID
- GET  /api/employees/{id}              – get by ID
- POST /api/employees                   – create (201 Created)
- PUT  /api/employees/{id}              – update (204 No Content)
- DELETE /api/employees/{id}            – delete (204 No Content)

---

## Design notes (short)
- **Separation of concerns:** Domain (entities), Application (contracts), Infrastructure (EF), API (transport).
- **DTOs + FluentValidation:** Stable API contract, prevent over-posting, consistent `ProblemDetails`.
- **Search performance:** Parse integer for ID; `EF.Functions.Like` for name; index on `FullName`.
- **Developer UX:** Swagger for exploration; clear HTTP status codes; CORS for Angular dev.

---

## Next steps (if extended)
Pagination/sorting, JWT auth + roles, integration tests, CI/CD pipeline, Docker Compose (SQL + API) + containerized UI.

---

## License
MIT
