# MyDiet
MyDiet is a little webapp made with the newest technology of Microsoft: Blazor. In this project I've used Blazor Server, in order to create a CRUD application and show how easy it can be to do it.

## What do you need
You will need at least: 
- Visual Studio 2017/2019 with the last .NET Core SDK
- SQL Server Express/Developer installed and active
- SQL Server Management Studio 15.0

## How To Use
- Open ".sln" file with Visual Studio
- Right click on the project and select "Manage User Secret" and paste these lines:

  > "ConnectionStrings": {
    "DefaultConnection": "Server={SERVER_CONNECTION_STRING};Database=MyDiet;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
- Replace the "{SERVER_CONNECTION_STRING}" tag with your SQL Server connection string
- Go to Tools -> Manage Nuget Packages -> Console Nuget Packages
- Once the PowerShell Console will be open, paste this line:

  > Update-Database
  
  This will ensure the creation of the database with all the migrations applied
  
#### Run the project and try it out.

## Future improvements
- Add Authentication in order to protect all routes
- Increase validation and business logic

## License
MyDiet is available under the MIT license. See the LICENSE file for more info.
