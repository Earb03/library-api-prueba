# 📚 Library API Prueba (.NET 8)

Este es un backend en **C# .NET 8**, construido como **API REST** que actúa como un _proxy_ entre el frontend y la API externa [FakeRestAPI](https://fakerestapi.azurewebsites.net/).

---

## 🏗️ Estructura del Proyecto

Se implementa una arquitectura limpia, separando responsabilidades en:

- `Controllers/` → Exposición de endpoints
- `Services/` → Lógica de negocio y conexión con API externa
- `Models/` → Entidades y DTOs usados internamente
- `Dtos/` → Estructuras enriquecidas (como Book + Authors)

---

## 🚀 Cómo correr el proyecto

### ✅ Requisitos

- [.NET 8 SDK o superior](https://dotnet.microsoft.com/download)
- Visual Studio 2022 o Visual Studio Code

### ▶️ Pasos

1. Clona el repositorio:

   ```bash
   git clone https://github.com/Earb03/library-api-prueba.git
   cd library-api-prueba

2. Restaura los paquetes:

   ```bash
    dotnet restore


3. Ejecuta el proyecto:
   
    ```bash
     dotnet run


## 📦 Endpoints disponibles

### 📘 Libros (`/api/books`)

```http
GET     /api/books           # Listar todos los libros
GET     /api/books/:id       # Obtener libro + autores por ID
POST    /api/books           # Crear un nuevo libro
PUT     /api/books/:id       # Actualizar un libro existente
DELETE  /api/books/:id       # Eliminar un libro
```
###  Autores (`/api/authors`)
```http
GET     /api/authors         # Listar todos los autores
GET     /api/authors/:id     # Obtener un autor por ID
POST    /api/authors         # Crear un nuevo autor
PUT     /api/authors/:id     # Actualizar un autor existente
DELETE  /api/authors/:id     # Eliminar un autor
```
###  Consideraciones 

- El backend actúa como un **proxy** entre el frontend y la API externa [FakeRestAPI](https://fakerestapi.azurewebsites.net).
- No se utiliza base de datos local, toda la persistencia es virtual y delegada a la API externa.
- Se implementó una estructura basada en principios de **Clean Architecture**, separando controladores, servicios, modelos y DTOs.
- El endpoint `/api/books/:id` está enriquecido y retorna tanto los datos del libro como los autores relacionados (`BookWithAuthorsDto`).
