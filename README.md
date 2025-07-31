# FundProcess Technical Test

Goal:

- Create a reusable service
- Create unit tests using the service with dependency injection
- If possible create a web api using this service 

## Used Dependencies

- XUnit
- Webapi
- .NET 9.0.303

## How to run the project

After cloning the repository, run the following commands:

```bash
    cd PERFORMANCESOLUTION
    # If you want to run the unit tests
    cd Performance.Test
    dotnet test

    # If you want to start up the API
    cd PerformanceAppRestApi
    dotnet run
```

You can then test the API endpoint ```/performance``` via Insomnia or Postman with the parameters ```from``` & ```to``` via ```GET``` request

You can test the following parameters: 

- from: 2021-01-01
- to: 2021-12-31
