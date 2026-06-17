# Transport System

Full-stack project: **ASP.NET Core Web API + PostgreSQL + Console Client**

System for managing:
- Drivers
- Transports
- Repairs

---

## 📦 Tech Stack

### Server
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- PostgreSQL
- Docker

### Client
- .NET Console App
- HttpClient API integration

---

## 🚀 How to Run

### 1. Start Docker (Database + Server)

From root project folder(TransportSystem):

```bash
docker compose up --build
```

Server will be available at:

http://localhost:5000

API base URL:

http://localhost:5000/api

### 2. Run Client Application

Open a new terminal:

```bash
cd Client/TransportClient
dotnet run
```