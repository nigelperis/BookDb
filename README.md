# Book API

This is a simple REST API built in C# using ASP.NET Core. It provides endpoints to manage books, including listing, adding, updating, and deleting books.

## Description

The Book API allows users to perform CRUD (Create, Read, Update, Delete) operations on books. It exposes the following endpoints:

- `GET /api/v1/book`: Retrieves a list of all books or a specific book by ID.
- `POST /api/v1/book`: Adds a new book to the database.
- `PUT /api/v1/book`: Updates an existing book.
- `DELETE /api/v1/book`: Deletes a book by ID or all books.

## Dependencies

This project requires the following dependencies:

- ASP.NET Core
- Entity Framework Core
- Microsoft.EntityFrameworkCore.SqlServer

## Getting Started

1. Clone the repository: `git clone https://github.com/nigelperis/BookDb.git`

2. Navigate to the project directory: `cd BookDb`

3. Build and run the project:
`dotnet build
dotnet run`

4. The API will be available at `http://localhost:5000`.

## Usage

- Use a tool like Postman or curl to interact with the API endpoints.
- Send HTTP requests to the appropriate endpoint (e.g., `GET /api/v1/book` to retrieve all books).

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.



