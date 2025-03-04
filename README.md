# Concurrency Web - EF Core

## Overview

The **Concurrency Web** project is designed to demonstrate and handle various **concurrency-related issues** in **Entity Framework Core** (EF Core). It covers various scenarios, such as the handling of **DbUpdateConcurrencyException**, **isolation levels**, and the use of **Fluent API** and **Data Annotations** for managing relationships between entities.

This project also includes both **Database First** and **Code First** approaches, offering a comprehensive guide to understanding **EF Core concurrency handling** in real-world applications.

## Features

- **Concurrency Management**: Demonstrates how to handle concurrency exceptions (e.g., `DbUpdateConcurrencyException`) using EF Core.
- **Isolation Levels**: Includes examples of how to configure isolation levels like **Snapshot** to ensure data consistency.
- **Fluent API & Data Annotations**: Provides in-depth examples of configuring relationships between entities using **Fluent API** and **Data Annotations**.
- **Database First & Code First**: Covers both **Database First** and **Code First** approaches to database management and schema generation in EF Core.
- **ASP.NET Core MVC Integration**: Includes an example of using **EF Core concurrency handling** in an **ASP.NET Core MVC** application.

## Project Structure

The project is organized as follows:

```plaintext
/Concurrency.Web
|-- /Controllers
|   |-- ConcurrencyController.cs
|-- /Models
|   |-- Product.cs
|-- /Migrations
|   |-- InitialCreate.cs
|-- /Data
|   |-- AppDbContext.cs
|-- /Views
|   |-- Concurrency
|   |   |-- Index.cshtml
|-- /Properties
|   |-- launchSettings.json
|-- .editorconfig
|-- .gitattributes
|-- Concurrency.Web.csproj
|-- UdemyEFCore.sln
```

### Key Files

- **Controllers**: Contains the controllers that handle user requests and implement business logic (e.g., `ConcurrencyController.cs`).
- **Models**: Defines the entities (e.g., `Product.cs`) that interact with the database via **EF Core**.
- **Migrations**: Includes migration files that manage schema changes (e.g., `InitialCreate.cs`).
- **Data**: Contains the **DbContext** class (e.g., `AppDbContext.cs`) for interacting with the database.
- **Views**: Includes the MVC views (e.g., `Index.cshtml`) for displaying data to the user.
- **.editorconfig**: Provides code style and formatting settings for the project.
- **.gitattributes**: Specifies Git attributes for the repository.
- **UdemyEFCore.sln**: The solution file that organizes the project.

## Setup Instructions

### Prerequisites

- .NET Core SDK 3.1 or later
- A relational database (e.g., SQL Server, SQLite) configured for EF Core

### Clone the Repository

Clone the repository to your local machine:

```bash
git clone <repository_url>
cd Concurrency.Web
```

### Restore Dependencies

Run the following command to restore the project dependencies:

```bash
dotnet restore
```

### Apply Migrations

To apply the EF Core migrations and set up the database schema, use the following command:

```bash
dotnet ef database update
```

### Run the Application

To run the application, use the following command:

```bash
dotnet run
```

By default, the application will be hosted at [http://localhost:5000](http://localhost:5000).

## Concurrency Handling

This project demonstrates how to handle **DbUpdateConcurrencyException**, which occurs when multiple users attempt to update the same data concurrently. The project includes techniques to handle this exception and resolve conflicts, ensuring that the application works correctly in multi-user environments.

### Key Scenarios Demonstrated:

1. **DbUpdateConcurrencyException**: Handle concurrency conflicts when saving changes to the database.
2. **Isolation Levels**: Set isolation levels like **Snapshot** to control how database transactions interact with each other.
3. **Fluent API & Data Annotations**: Configure relationships between entities using **Fluent API** and **Data Annotations**.

## API Endpoints

The following API endpoints are available in the application:

- **GET /api/products**: Retrieves a list of all products.
- **POST /api/products**: Creates a new product.
- **PUT /api/products/{id}**: Updates an existing product (handles concurrency issues).
- **DELETE /api/products/{id}**: Deletes a specific product.

## Project Development

We welcome contributions to improve and extend the functionality of this project. If you'd like to contribute, follow these steps:

1. Fork the repository.
2. Clone your fork locally.
3. Create a new branch for your changes.
4. Commit your changes.
5. Push your changes to your fork.
6. Submit a pull request to the original repository.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## Acknowledgements

This API was created using **ASP.NET Core** and **Entity Framework Core**, and it demonstrates various **concurrency** and **transaction management** techniques. A special thank you to the **Udemy** course resources for providing insights into EF Core and concurrency handling.

For more information on EF Core and ASP.NET Core, please refer to the official documentation.

---
