# EmailLogging

## Description

Simple web-service without UI for sending emails and storing info about sent emails

Used technologies: 
- Visual Studio 2022
- .Net 8.0
- Asp.net core MVC
- EntityFramework
- PostgreSQL
- MailKit
- Gmail SMTP
- Postman

## How to start 

### 1) [Install PostgreSQL](https://www.postgresql.org/download/)

### 2) create configuration file `appsettings.json` in project directory:

file content:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": { "PostgreSQL": "Host=localhost;Port=5432;Database=<database name>;Username=<database name>;Password=<database password>" },
  "EmailConfiguration": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 587,
    "Username": "<username for SMTP>",
    "Password": "<password for SMTP>",
    "SenderName": "<sender name>",
    "SenderEmail": "<sender email address>"
  }
}
```

### 3) Create database:

Write in package manager console in visual studio next command:\
`Update-Database`

or write in CLI next command\
`dotnet ef database update`

### 4) Start web-service:

You can start from Visual Studio by `F5` or clicking run button

or you can start by CLI in `EmailLogging` directory writing `dotnet run` command

### 5) use Postman or analogs to communicate with web-service:

url: `https://localhost:7270/api/mails`