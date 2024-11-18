# Hotel Reservation API

## Overview

The Hotel Reservation API is a minimalistic RESTful service designed to manage hotel room reservations. It follows the principles of Domain-Driven Design (DDD) and utilizes a Vertical Slice Architecture. The API is built using ASP.NET Core and leverages MediatR for handling commands and queries, Fluent Validation for input validation, and Swagger for API documentation.

## Features

- **Room Reservation**: Reserve hotel rooms using a unique identifier.

## Technologies Used

- .Net 8
- MediatR
- FluentValidation
- Swagger/OpenAPI

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A code editor (e.g., Visual Studio, Visual Studio Code)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/sathishsuresh04/HotelReservationManagement
   ```

2. Restore the dependencies:

   ```bash
   dotnet restore
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

### Configuration

The application settings can be found in the `appsettings.json` file. You can configure logging levels, allowed hosts, and OpenAPI information here.

### API Endpoints

#### Reserve Room

- **POST** `/api/v{version}/reservations/reserve`

  **Request Body**:
  ```json
  {
    "roomIdentifier": "ColumbiaSC-Room101"
  }
  ```

  **Responses**:
    - `200 OK`: Room reserved successfully.
    - `400 Bad Request`: Validation errors or room already reserved.

### Testing

Unit tests are included in the `tests` directory. To run the tests, use the following command:
