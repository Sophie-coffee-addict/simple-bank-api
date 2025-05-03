# 💸 Simple Bank Payments API

A mock .NET 6 Web API for simulating bank transfers. Built with RESTful design, containerised using Docker, and integrated with GitHub Actions for CI.

![Build](https://github.com/Sophie-coffee-addict/simple-bank-api/actions/workflows/dotnet.yml/badge.svg)

---

## Features

- ✅ POST API endpoint to simulate bank transfers
- ✅ Validates sender, receiver, and amount fields
- ✅ Generates unique transaction ID and timestamp
- ✅ Containerised with Docker
- ✅ CI pipeline with GitHub Actions

---

## Tech Stack

- ASP.NET Core 6 Web API
- C#
- Docker
- GitHub Actions
- Postman (for manual testing)

---

## Sample Request

**POST** `/api/transfer`

```json
{
  "fromAccount": "123456789",
  "toAccount": "987654321",
  "amount": 250.75
}
```

## Sample Response

```json
{
  "transactionId": "a8a4d483-c3a6-46b3-922f-bb52cdfdc863",
  "status": "Success",
  "timestamp": "2025-05-03T05:20:37.0781199Z"
}
```

## Run Locally

```bash
dotnet run
```

Access via:
https://localhost:7290/api/transfer

## Run with Docker

docker build -t simple-bank-api .
docker run -d -p 8080:80 simple-bank-api

Then POST to:
http://localhost:8080/api/transfer

## Project Structure

📦SimpleBankPaymentsAPI
┣ 📂Controllers
┃ ┗ 📜TransferController.cs
┣ 📂Models
┃ ┗ 📜TransferRequest.cs
┣ 📜Program.cs
┣ 📜Dockerfile
┣ 📜README.md
┗ 📂.github/workflows
┗ 📜dotnet.yml
