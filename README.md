## Requirements

1.  Dotnet core [sdk](https://www.microsoft.com/net/download/windows) 2.1 or later
2.  Visual studio 2017 version 15.3 or later / VSCODE
3.  [Nodejs](https://nodejs.org/en/) latest version
4.  SQL Server 2012 or later
5.  For terminal use [CMDER](http://cmder.net/)
6.  Additional software --> [Git for Windows](https://git-scm.com/download/win)

## How to run

1.  Install all require softwares mentioned above
2.  Clone this repository
3.  Open Project folder in visual studio / VS code
4.  If using visual studio
    1.  Right click on project folder and restore nuget Packages
    2.  Create database tables and change connection string in appsettings.json file
    3.  Build and run Project
5.  If using vsCode

    1.  open terminal in current folder and run

        ```bash
            dotnet restore

            # then create databse and replace connectionString

            dotnet run # open browser and visit https://localhost:50001
        ```

## **Creating Databse and configuring connectionString**

### Create Local Database [reference from here](https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db)

- Open Visual Studio
- Tools -> Connect to Database...
- Select Microsoft SQL Server and click Continue
- Enter (localdb)\mssqllocaldb as the Server Name
- Enter master as the Database Name and click OK
- The master database is now displayed under Data Connections in Server Explorer
- Right-click on the database in Server Explorer and select New Query
- Copy the script, listed below, into the query editor
- Right-click on the query editor and select Execute

```sql
CREATE DATABASE [HallBooking];
GO

USE [HallBooking];
GO

CREATE TABLE [Customer] (
    [CustomerId] int NOT NULL IDENTITY,
    [UserName] varchar(30) not null,
    [Name] varchar(50) not null,
    [MobileNo] varchar(20),
    [Password] varchar(20) not null,
    [Email] varchar(30),
    CONSTRAINT [PK_Customer] PRIMARY KEY ([CustomerID])
);
GO
```

### Connect to newly created databse

- Tools -> Connect to Database...
- Select Microsoft SQL Server and click Continue
- Enter (localdb)\mssqllocaldb as the Server Name
- Enter HallBooking as the Database Name and click OK

### Install Entity Framework to dotnet App

> Open Package Manager Console and run these

    ```bash
    # Go to Tools > NuGet Package Manager > Package Manager Console

    Install-Package Microsoft.EntityFrameworkCore.SqlServer

    Install-Package Microsoft.EntityFrameworkCore.Tools
    ```

### generate Models from DB Table

```cmd
    Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=HallBooking;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```

### Register created Dbcontext with dependency injection

1.  Open HallBookingContext.cs and Replace **protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)** method with this
    ```cs
        public BloggingContext(DbContextOptions<HallBookingContext> options): base(options){ }
    ```
2.  Register and configure your context in Startup.cs
    ```cs
    // Add line to configureServices method
    services.AddDbContext<HallBookingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        // Configuration.GetConnectionString("Default") reads appsettings.json file.
        // And choose value of 'Default' key
    ```
3.  Add ConnectionString to appsettings.json
    ```json
        "ConnectionStrings": {
            "DefaultConnection": "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=HallBooking;Integrated Security=True"
        }
    ```
