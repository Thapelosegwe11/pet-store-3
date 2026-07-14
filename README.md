markdown# pet-store-3

![NUnit](https://img.shields.io/badge/NUnit-3.13-blue) ![OpenAPI](https://img.shields.io/badge/OpenAPI-Generator-orange) ![.NET](https://img.shields.io/badge/.NET-8.0-purple) ![Docker](https://img.shields.io/badge/Docker-Compose-blue)

## Description
Automated API tests for the Swagger Petstore application using an OpenAPI generated client in C# and NUnit. Instead of writing raw HTTP requests, the client code is automatically generated from the Swagger API definition file, making tests cleaner and easier to maintain.

## 🛠️ Tech Stack
- **Language:** C#
- **Testing Framework:** NUnit
- **API Client:** OpenAPI Generator (auto-generated)
- **Dependencies:** RestSharp, Newtonsoft.Json, JsonSubTypes, Polly
- **System Under Test:** Swagger Petstore (via Docker)

## 📁 Project Structure
pet-store-3/
├── OpenApiTests/
│   ├── Api/               # Auto-generated API classes
│   ├── Client/            # Auto-generated HTTP client code
│   ├── Model/             # Auto-generated data models
│   ├── InventoryTests.cs  # Tests for GET /store/inventory
│   ├── PetTests.cs        # Tests for pet endpoints
│   └── OrderTests.cs      # Tests for placing orders
├── GeneratedApiCode/      # Raw OpenAPI generated code
└── .lms/
└── exercises.toml     # School submission file

## ✅ Prerequisites
- .NET 8.0
- Docker
- Java (for OpenAPI Generator)

## ⚙️ Installation
Clone the repo:
```bash
git clone git@github.com:Thapelosegwe11/pet-store-3.git
cd pet-store-3
```

## 🐳 Running the Petstore API with Docker
```bash
docker run -d -p 80:8080 -e SWAGGER_BASE_PATH=/v2 swaggerapi/petstore
```

Verify it's running at:
http://localhost:80

## 🧪 Running the Tests
```bash
cd OpenApiTests
dotnet test
```

## 📋 Test Cases
| Test Class | Test | Description |
|------------|------|-------------|
| InventoryTests | GetInventoryShouldReturnInventory | Verifies inventory contains sold, pending, available |
| PetTests | GetPetThatExists | Verifies retrieving pet with id 1 |
| PetTests | GetPetThatDoesNotExist | Verifies handling of missing pet id 99 |
| PetTests | AddPet | Verifies adding a new pet |
| PetTests | RemovePet | Verifies removing a pet |
| OrderTests | PlaceOrder | Verifies placing an order for a pet |

## 🎯 Key Concepts
- **OpenAPI Generator** — automatically generates C# client code from the Swagger API definition
- **Generated Models** — no manual JSON parsing, models are auto-generated
- **Clean Tests** — test code contains zero HTTP client code, only domain logic

## 🔧 Troubleshooting
- **Connection refused** — Make sure Docker is running and Petstore container is up
- **.NET version error** — Make sure you have .NET 8.0 installed
- **Build errors** — Do not copy the `.csproj` files from the generated code

## 📄 License
This project is for educational purposes at WeThinkCode_.
