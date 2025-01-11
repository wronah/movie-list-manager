# University project
This is a repository for a class project at WSEI. (Programming in ASP.NET)
- [x] finish project
# Movie List Manager

A web-based application for managing a list of movies. This project is written in C# using the ASP.NET MVC framework. The application allows users to perform CRUD (Create, Read, Update, Delete) operations on a movie database.

## Table of Contents

1. [Requirements](#requirements)
2. [Installation](#installation)
3. [Configuration](#configuration)
    - [Connection String](#connection-string)
    - [Test Users and Passwords](#test-users-and-passwords)
4. [Application Flow](#application-flow)

## Requirements

To run the project, you will need:

- **.NET SDK**: Version 8.0 or higher
- **Visual Studio**: 2022 or higher (with ASP.NET and web development workload)
- **SQL Server**: LocalDB or any SQL Server instance
- **Browser**: A modern web browser (e.g., Chrome, Edge, Firefox)

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/wronah/movie-list-manager.git
    cd movie-list-manager
    ```

2. Open the project in Visual Studio.

3. Restore NuGet packages:
    - In Visual Studio, open the **Tools** menu and select **NuGet Package Manager > Manage NuGet Packages for Solution**.
    - Restore the packages listed in `packages.config` or by running:
      ```bash
      dotnet restore
      ```

4. Set up the database:
    - Ensure your SQL Server instance is running.
    - Update the connection string in `appsettings.json` (see [Configuration](#configuration)).
    - Open the **Package Manager Console** in Visual Studio and run:
      ```bash
      Update-Database
      ```

5. Run the project:
    - Press `F5` in Visual Studio or run the project using:
      ```bash
      dotnet run
      ```

## Configuration

### Connection String

The database connection string is located in the `appsettings.json` file in the root of the project:

```json
"ConnectionStrings": {
    "ApplicationDbContextConnection": "Server=(localdb)\\MSSQLLocalDB;Database=movie-list-manager;Trusted_Connection=True;TrustServerCertificate=True;
}
```

Modify the `Server` and `Database` fields to match your SQL Server configuration.

### Test Users and Passwords

The application comes preloaded with test users for demonstration purposes. Below are the default credentials:

| Username       | Password      | Role         |
|----------------|---------------|--------------|
| admin@admin.com | !Admin123     | Administrator |
| user@user.com  | !Admin123      | Regular User  |

You can modify or add more test users by updating the database or using the application’s user management features.

## Application Flow

As a normal User you are able to add movies to your movie list (you can rate the movie and you can set the date you watched it, as well as some details about the movie).     
      You can edit the movies and remove them from the list.                        
You can also check the details of the movie you added.              

As an administrator you are able to see all of the movies added to the application. You can perform the same operations as the normal User.                   
You can also add Tags and Genres for normal Users to choose when creating movies.                      
You can perform basic CRUD operations on all entities (Movie, Tag, Genre).            

---
