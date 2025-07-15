# 🌦️ Weather App – Infrastructure with Redis & RabbitMQ (REST APIs)

This repository demonstrates infrastructure-focused patterns using **Redis for caching** , **RabbitMQ for messaging** and **Serilog for logging** in .NET REST APIs. These are built around a simplified Weather App use case, showing how infrastructure concerns can be modularized and cleanly integrated.

---
# Authors

## Vishwa Kumar
- **Email:** vishwa@vishwa.me
- **GitHub:** [Vishwam](https://github.com/vishwamkumar)
- **LinkedIn:** [Vishwa Kumar](https://www.linkedin.com/in/vishwamohan)

Vishwa is the primary developer and architect of this example app, responsible for the architecture and implementation of these features.


## 📦 Projects

| Project | Description |
|--------|-------------|
| `WeatherApp.RestApi.UsingBackgroundService` | Implements a background service for polling weather data at configurable intervals, with optional API-based triggering. |
| `WeatherApp.RestApi.RedisCache` | Implements Redis caching to store and retrieve weather data for optimized performance. |
| `WeatherApp.RestApi.RabbitMQ`   | Implements RabbitMQ-based message queueing to asynchronously publish and process weather updates. |
| `WeatherApp.RestApi.Serilog`   | Implements Serilog to log app log, transaction log and custom logs in a REST API. |
| `WeatherApp.BlazorApp.Serilog`   | Implements Serilog to log app log, transaction log and custom logs in a Blazor Web App. |


Each project is **self-contained** and includes its own `.sln` file for independent testing.

---

## ▶️ Getting Started

### 🔁 Clone the Repository

```bash
git clone https://github.com/vishwamkumar/weather-app.infrastructure.rest-apis.git
cd weather-app.infrastructure.rest-apis



## 🚀 Run a Project
    Pick one of the projects to test. For example:

    ```bash
        cd WeatherApp.RestApi.RedisCache
        dotnet run
    ```
    Replace RedisCache with RabbitMQ to test the other pattern.


## 🧪 Test Scenarios
    Each project includes a Docs/TestMe.md file with example queries and test scenarios specific to the authentication scheme in use.


## 📂 Folder Structure

  weather-app.infra-patterns.rest-apis/
      ├── WeatherApp.RestApi.UsingBackgroundService/
      ├── WeatherApp.RestApi.UsingRedisCache/
      ├── WeatherApp.RestApi.UsingRabbitMQ/
      ├── WeatherApp.RestApi.UsingSerilog/
      └── WeatherApp.BlazorServer.UsingSerilog/


## 🛠️ Tech Stack

  1. .NET 9
  2. ASP.NET Core Web API
  3. Redis (via StackExchange.Redis)
  4. RabbitMQ (via RabbitMQ.Client)
  5. Serilog

---
## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
