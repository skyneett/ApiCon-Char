# API con ASP.NET Core y MVC Client

Este proyecto contiene una solución .NET 8 con dos proyectos:

## Proyectos

### 1. ejemploApi
Una API REST construida con ASP.NET Core que proporciona endpoints para gestionar productos.

**Características:**
- API RESTful con Entity Framework Core
- Controlador de Productos con operaciones CRUD
- Base de datos SQLite
- Puerto: http://localhost:5129

### 2. ApiMVC
Una aplicación web MVC que consume la API.

**Características:**
- Cliente MVC para consumir la API
- Vistas Razor para gestión de productos (Index, Create, Edit, Delete, Details)
- Servicio HttpClient para comunicación con la API
- Bootstrap para estilos

## Requisitos

- .NET 8 SDK
- Visual Studio 2022 o VS Code

## Configuración

1. Clonar el repositorio:
```bash
git clone https://github.com/skyneett/ApiCon-Char.git
cd ejemploApi
```

2. Restaurar paquetes NuGet:
```bash
dotnet restore
```

3. Actualizar la base de datos:
```bash
cd ejemploApi
dotnet ef database update
```

## Ejecución

### Opción 1: Visual Studio
1. Abrir `ejemploApi.sln` en Visual Studio
2. Configurar múltiples proyectos de inicio (ejemploApi y ApiMVC)
3. Presionar F5 para ejecutar

### Opción 2: Línea de comandos

En una terminal, ejecutar la API:
```bash
cd ejemploApi
dotnet run
```

En otra terminal, ejecutar el cliente MVC:
```bash
cd ApiMVC
dotnet run
```

## Endpoints de la API

- `GET /api/productos` - Obtener todos los productos
- `GET /api/productos/{id}` - Obtener un producto por ID
- `POST /api/productos` - Crear un nuevo producto
- `PUT /api/productos/{id}` - Actualizar un producto
- `DELETE /api/productos/{id}` - Eliminar un producto

## Estructura del Proyecto

```
ejemploApi/
??? ejemploApi/              # Proyecto API
?   ??? Controllers/
?   ??? Models/
?   ??? Migrations/
?   ??? Program.cs
??? ApiMVC/                  # Proyecto MVC Client
?   ??? Controllers/
?   ??? Views/
?   ??? Services/
?   ??? Program.cs
??? README.md
```

## Tecnologías Utilizadas

- ASP.NET Core 8.0
- Entity Framework Core
- SQLite
- Bootstrap 5
- jQuery

## Configuración de la API

La URL base de la API se configura en `ApiMVC/appsettings.json`:
```json
{
  "ApiSettings": {
    "ApiBaseUrl": "http://localhost:5129/api/"
  }
}
```

## Licencia

Este proyecto es de código abierto y está disponible bajo la licencia MIT.
