# Hotel Reservation API and Stock Analyzer

## Overview

The Hotel Reservation API is a minimalistic RESTful service designed to manage hotel room reservations. It follows the
principles of Domain-Driven Design (DDD) and utilizes a Vertical Slice Architecture. The API is built using ASP.NET Core
and CQRS pattern leverages MediatR for handling commands and queries, Fluent Validation for input validation, and Swagger for API
documentation

The Stock Analyzer is a console application designed to calculate the maximum profit from stock prices and find the k-th highest stock price. It provides efficient algorithms for stock price analysis, making it easier for users to make informed investment decisions.

## Features

- **Room Reservation**: Reserve hotel rooms using a unique identifier.

- **Max Profit Calculation**: Calculate the maximum profit that can be made by buying and selling stocks.

- **K-th Highest Price**: Retrieve the k-th highest stock price from a list of prices.

## Technologies Used

- .Net 8
- MediatR
- FluentValidation
- Swagger/OpenAPI
- NSubstitute

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

The application settings can be found in the `appsettings.json` file. You can configure logging levels, allowed hosts,
and OpenAPI information here.

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

### Stock Analyzer Console Application

To run the Stock Analyzer, navigate to the Stock Analyzer project directory and execute the following command:

```bash
dotnet run
```

#### Console Outputs

- **Max Profit Calculation**: The console will display the maximum profit that can be achieved from the given stock prices.

- **K-th Highest Price**: The console will also display the k-th highest stock price based on the provided input.

### Testing

Unit tests are included in the `tests` directory. To run the tests, use the following command:

```bash
dotnet test
```
