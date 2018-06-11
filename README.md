## **Creating Databse and configuring connectionString**
### Create Local Database [reference from here](https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db)
* Open Visual Studio
* Tools -> Connect to Database...
* Select Microsoft SQL Server and click Continue
* Enter (localdb)\mssqllocaldb as the Server Name
* Enter master as the Database Name and click OK
* The master database is now displayed under Data Connections in Server Explorer
* Right-click on the database in Server Explorer and select New Query
* Copy the script, listed below, into the query editor
* Right-click on the query editor and select Execute

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
* Tools -> Connect to Database...
* Select Microsoft SQL Server and click Continue
* Enter (localdb)\mssqllocaldb as the Server Name
* Enter HallBooking as the Database Name and click OK

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
1. Open HallBookingContext.cs and Replace __protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)__ method with this
    ```cs
        public BloggingContext(DbContextOptions<BloggingContext> options): base(options){ }
    ```
2. Register and configure your context in Startup.cs
    ```cs
    // Add line to configureServices method
    services.AddDbContext<HallBookingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"))); 
        // Configuration.GetConnectionString("Default") reads appsettings.json file.
        // And choose value of 'Default' key 
    ```
3. Add ConnectionString to appsettings.json
    ```json
        "ConnectionStrings": {
            "Default": "Server=(localdb)\\mssqllocaldb;Database=HallBooking;Trusted_Connection=True;MultipleActiveResultSets=true"
        }
    ```

