# OrderFlow API

OrderFlow is a restaurant order management API developed as a portfolio project.

## Architecture

- Clean Architecture
- Domain-Driven Design concepts
- Result Pattern
- Repository Pattern
- Value Objects

## Technologies

- .NET 8
- ASP.NET Core
- Entity Framework Core
- PostgreSQL

## Current Features

### Products

- Create Product
- Update Product
- Get Product By Id
- Get Products
- Activate Product
- Deactivate Product

## Roadmap

- Authentication & Authorization
- Order Management
- Customer Management
- Angular Frontend

## Running the project

### Configure the connection string

Use User Secrets:

```bash
dotnet user-secrets init \
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<connection-string>"
```

### Apply migrations

```bash
dotnet ef database update
```

### Run the API

```bash
dotnet run --project src/OrderFlow.Presentation
```

I would still mention Docker somewhere if it's part of your development workflow:

## Development Environment

During development, PostgreSQL is typically executed using Docker containers.

## Project Status

Current Version: v0.1.0

Completed:
- Product Management Module

In Progress:
- Authentication & Authorization
