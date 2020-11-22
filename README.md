# CleanArchitectureApp
Clean Architecture Application Design from Scratch using Dotnet Core 3.1 WebApi and Angular 11 FrontEnd

[![MIT license](http://img.shields.io/badge/license-MIT-brightgreen.svg)](http://opensource.org/licenses/MIT)

## Technologies
- [ASP.NET Core 3.1](https://dotnet.microsoft.com/)
- [NHibernate](https://nhibernate.info/)
- [Angular 11](https://angular.io/)
- [Angular CLI 11](https://cli.angular.io/)
- [Clean Architecture]()
- [Swashbuckle.AspNetCore.Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- Design Pattern: Command Query Responsibility Segregation (CQRS)
- [Fluent Validation](https://fluentvalidation.net/)
- WebAPI Global Exception Middleware
- Login, Logout and Forgot Password using JWT tokens

## Pre-requisites
1. [.Net core 3.1 SDK](https://www.microsoft.com/net/core#windows)
2. [Visual studio 2019](https://www.visualstudio.com/) OR [VSCode](https://code.visualstudio.com/) with [C#](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) extension
3. [NodeJs](https://nodejs.org/en/) (Latest LTS)
4. [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2017) (Optional: If MS SQL server required instead of Sqlite during development)

## Configuration

1. Clone the repo: git clone  https://github.com/sunilkumarmedium/CleanArchitectureApp.git
2. Execute the sql scripts available in the folder /sql/CleanArchitectureDB.sql
3. Change the database connectionstring in appsettings.json 
   - Path : CleanArchitectureApp.WebApi/appsettings.Development.json
4. open the CleanArchitectureApp.sln
   - Visual Studio 2019 IDE
      - opening the solution will restore the nuget and npm packages build the solution
      - Multiple Projects Startup CleanArchitectureApp.WebApi and CleanArchitectureApp.UserInterface.AngularWeb
   - Visual Studio Code
     - Open the folder CleanArchitectureApp
     - Build the Solution
     - Run the Projects CleanArchitectureApp.WebApi and CleanArchitectureApp.UserInterface.AngularWeb
 5. Test User to Login
    - Username: system 
    - Password: admin@123
     


   
