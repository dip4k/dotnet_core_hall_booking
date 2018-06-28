## Requirements

1.  Dotnet core [sdk](https://www.microsoft.com/net/download/windows) 2.1 or later
2.  Visual studio 2017 version 15.3 or later / VSCODE
3.  [Nodejs](https://nodejs.org/en/) latest version
4.  SQL Server 2012 or later
5.  For terminal, use [CMDER](http://cmder.net/)
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
CREATE TABLE [dbo].[Users] (
    [UserId]   INT           IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [MobileNo] NVARCHAR (15) NOT NULL,
    [Role]     NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);
GO
CREATE TABLE [dbo].[Admins] (
    [AdminId] INT           IDENTITY (2001, 1) NOT NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    [Email]   NVARCHAR (50) NULL,
    [UserId]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([AdminId] ASC),
    CONSTRAINT [FK_AdminUserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO
CREATE TABLE [dbo].[HallOwners] (
    [HallOwnerId] INT IDENTITY (3001, 1) NOT NULL,
    [UserId]      INT NOT NULL,
    PRIMARY KEY CLUSTERED ([HallOwnerId] ASC),
    CONSTRAINT [FK_OwnerUserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO
CREATE TABLE [dbo].[Customers] (
    [CustomerId] INT            IDENTITY (5001, 1) NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [Email]      NVARCHAR (50)  NULL,
    [Address]    NVARCHAR (MAX) NULL,
    [AadharNo]   NVARCHAR (20)  NULL,
    [UserId]     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    CONSTRAINT [FK_CustomerUserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);
GO
CREATE TABLE [dbo].[Bookings] (
    [BookingId]   INT      IDENTITY (10001, 1) NOT NULL,
    [BookingDate] DATETIME NOT NULL,
    [HallOwnerId] INT      NOT NULL,
    [CustomerId]  INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([BookingId] ASC),
    CONSTRAINT [FK_BookingOwnerId] FOREIGN KEY ([HallOwnerId]) REFERENCES [dbo].[HallOwners] ([HallOwnerId]),
    CONSTRAINT [FK_BookingCustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
);
GO
CREATE TABLE [dbo].[HallDetails] (
    [HallDetailId] INT            IDENTITY (20001, 1) NOT NULL,
    [HallName]     NVARCHAR (MAX) NOT NULL,
    [HallCapacity] INT            NOT NULL,
    [HallOwnerId]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([HallDetailId] ASC),
    CONSTRAINT [FK_HallOwnerId] FOREIGN KEY ([HallOwnerId]) REFERENCES [dbo].[HallOwners] ([HallOwnerId])
);
GO
CREATE TABLE [dbo].[FeaturePrices] (
    [Id]            INT             IDENTITY (30001, 1) NOT NULL,
    [HallPrice]     DECIMAL (10, 2) NOT NULL,
    [CateringPrice] DECIMAL (10, 2) NULL,
    [BanjoPrice]    DECIMAL (10, 2) NULL,
    [FlowerPrice]   DECIMAL (10, 2) NULL,
    [HallOwnerId]   INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PricingHallOwnerId] FOREIGN KEY ([HallOwnerId]) REFERENCES [dbo].[HallOwners] ([HallOwnerId])
);
```

### Connect to newly created databse

- Tools -> Connect to Database...
- Select Microsoft SQL Server and click Continue
- Enter (localdb)\mssqllocaldb as the Server Name
- Enter HallBooking as the Database Name and click OK

### Install Entity Framework to dotnet App

> Open Package Manager Console and run these

```sh
# Go to Tools > NuGet Package Manager > Package Manager Console

Install-Package Microsoft.EntityFrameworkCore.SqlServer

Install-Package Microsoft.EntityFrameworkCore.Tools
```

### generate Models from DB Table

```sh
    Scaffold-DbContext "Data Source=(localdb)\mssqllocaldb;Initial Catalog=HallBooking;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir BOL
```

```sh
#for vsCode
dotnet ef dbcontext scaffold "Data Source=(localdb)\mssqllocaldb;Initial Catalog=HallBooking;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -o BOL
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
    ```js
        "ConnectionStrings": {
            "DefaultConnection": "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=HallBooking;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        }
    ```
