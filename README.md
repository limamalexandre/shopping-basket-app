# Shopping Basket Application

This is a full-stack technical assessment project. The application allows users to add products to a shopping basket, calculates the total price with applicable discounts, generates a detailed receipt (which is also saved as a transaction).

## Table of Contents

- [Prerequisites](#prerequisites)
- [Backend Setup](#backend-setup)
- [Database Setup](#database-setup)
- [Frontend Setup](#frontend-setup)
- [Running the Application](#running-the-application)
- [Testing](#testing)
  - [Backend Unit Tests (xUnit)](#backend-unit-tests-xunit)
  - [Frontend Integration Tests (Cypress)](#frontend-integration-tests-cypress)

---

## Prerequisites

- **.NET 6+ SDK** – for building and running the backend.
- **Node.js & npm** – for Angular and installing dependencies.
- **Angular CLI (v19+)** – to build and serve the frontend.
- **MySQL Server** – for the database.
- **EF Core Tools** – for migrations (install via `dotnet tool install --global dotnet-ef` if needed).
- **Cypress** – for frontend integration testing (installed as a dev dependency).

---

## Backend Setup

1. Clone the repository to your local machine.

2. In the backend project folder, open "appsettings.json" and update the connection string to point to your MySQL instance. For example:
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ShoppingBasketDb;User=basket_user;Password=your_password;"
  }

3. Open a terminal in the backend folder and run:
  dotnet restore
  dotnet build

4. Run the EF Core migrations to create/update the database schema:
  dotnet ef migrations add InitialCreate
  dotnet ef database update

5. Start the backend by running: dotnet run
The API should be accessible (for example, at https://localhost:5001 or https://localhost:7189).

---

## Database Setup

1. Install MySQL Server if not already installed (on Windows, use the MySQL Installer; on macOS, use Homebrew; on Linux, use your package manager).

2. Secure your MySQL installation (e.g., run "mysql_secure_installation" if applicable).

3. Open a command prompt and log into MySQL: mysql -u root -p

4. Create the database: CREATE DATABASE ShoppingBasketDb; EXIT;

5. Apply EF Core migrations by running: dotnet ef database update

---

## Frontend Setup
1. Navigate to the Frontend folder (shopping-basket-frontend).

2. Install dependencies by running: npm install

3. In "src/environments/environment.ts", update the base API URL to:
  export const environment = {
  production: false,
  apiUrl: 'https://localhost:5001/api'
  };

4. Start the Angular development server by running: ng serve
The app should be available at http://localhost:4200.

---

## Running the Application
1. Start the backend, in the backend folder, run: dotnet run
  
2. Start the frontend, in the Angular project folder, run: ng serve
   
3. Open your browser and navigate to http://localhost:4200. Use the basket form to add product quantities and generate a receipt.

---

## Testing

### Backend Unit Tests (xUnit)
1. The test project is located in the "Tests" folder.
   
2. From the solution root, run: dotnet test

### Frontend Integration Tests (Cypress)
1. Navigate to the Angular project folder.
 
2. Install Cypress (if not already installed): npm install cypress --save-dev
 
3. Open the Cypress Test Runner by running: npx cypress open or run headless tests with: npx cypress run
