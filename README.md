# Payment Service

### Requirements

* Git (for cloning repository)
* ASP.NET Core 2.1 SDK
* Microsoft Visual Studio 2017 Community Edition or higher or VSCode
* YARN

### Features

* Web API using ASP.NET Core 2.1
* Swagger (Swashbuckle)
* AutoMapper
* Unit Tests using MSTest + ASP.NET Core 2.1
* Frontend using AngularJS (basic structure)

### Building and executing

Clone repository:
```sh
git clone https://github.com/victormasutani/PaymentService.git
```

Install Yarn Global
```sh
npm install -g yarn
```

Restore packages yarn
```sh
cd PaymentService\PaymentService.API
yarn install
```

Change API hosting port if necessary (default port running from VSCode is 44341)
```sh
cd PaymentService\PaymentService.Web\src\services\payment\payment.service.js
```

Run API project
```sh
PaymentService\PaymentService.API
dotnet run
```

Run Web project
```sh
PaymentService\PaymentService.Web
yarn start
Open http://localhost:3000/
```

### Testing

Unit test API project (from VS 2017 or VSCode)
```sh
PaymentService\PaymentService.Tests
dotnet test
```
