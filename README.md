# .NET Core with Razor
Simple .NET Core project using Razor pages with Entity framework.

## Definition
Basic example of a web project created with .NET Core.
Hope this example help others as point of reference to start learning programming with .NET Core.

## Project Definition
Book Store
- CRUD of Books.
- MVC architecture
- FrontEnd with Razor

## Project structure
- **Project file (.csproj)**: Contains all the package reference installed in your project.
- **Properties**
  - **launchSetting.json**: Default configuration used when *Run* the project. (Environment variables, ApplicationURL, etc).
- **wwwroot folder**: Root folder for the website. Contains static files. (css,js,lib)
- **Pages folder**: Contains the Razor pages of the website.
  - **Shared/__Layout.cshtml**: Default masterpage for the application.
  - **Shared/__ValidationScriptsPartial.cshtml**: Scripts used for validation.
  - **__VieStart.cshtml**: used to define the default masterpage layout.
  - **Index.cshtml**: default page.
  - **Error.cshtml**: default error page.
- **appsettings.json**: contains the application's settings. If change, restart is required.

## Basic Concepts
- Routing
  - Maps URL's to Physical file on disk. 
  - Needs a root folder
  - Index.cshtml is a default document
- Tag Helpers
  - Has prefix *asp-*
  - Enable server-side code for creating and rendering HTML elements in Razor files.
- Main Method
  - Defined in Program.cs
- Startup
  - use a configuration object passed by DI.
- Pipelines
  - Are compose by individual parts named Middleware.
  - Middleware used in .NET Core: Auth, MVC, Static Files
  - IIS--> Dotnet--> Application --> Middleware
  - 2 Webservers: External (IIS, Apache ), Internal.
- Middleware
  - Receive the request from web browser and the middleware processes the context object through pipelines to send a response back.
- DI
  - NET Core injects objects of dependency classes through constructor or method by using built-in IOC container.
  - Help to decouple the different pieces of the applications.

## Creating our project.
1. Add Nuget Packages
    - RuntimeCompilation
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.SqlServer.Tools
2. Go to Startup and modify ConfigurationServices:

```C#
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages().AddRazorRuntimeCompilation();
    }
```

2. Add a new folder named *Books* into the *Pages* folder.
3. Add a new folder named *Model* into the project.
4. Create Book Model
    - Right-click Model Folder
    - Add new Class named *Book*
    ```C#
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
    }
    ```
5. Setup ConnectionString into the *AppSettings.json* file
```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=(LocalDb)\\SQLEXPRESS;Database=trainingdb;Trusted_Connection=True;MultipleActiveResultSets=True"
  }
```
6. Create ApplicationDbContext class into Model Folder
```C#
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
    }
```
7. Modify Startup.ConfigureServices
```C#
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(option=>option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddRazorPages().AddRazorRuntimeCompilation();
    }
```

8. Add Book table to Database (Migration)
    - Go to Tools-> Nuget Package Manager -> Package Manager Console
    - Command ```add-migration addBookToDb```
    - New migration file must be created into the Migrations folder.
    - Command ```update-database```
    - Go to SQL Server an validate that Book table was created.
    
9. Create Index page
    - Add Razor Page
      - Right-click on Book folder
      - Choose Add -> Razor Page
      - Razor Page name: Index
    - Add DbContext call by DI
      ```C#
      //Add readonly property.
      private readonly ApplicationDbContext db;
      // Add construct class with dbContext parameter injected by DI
      public IndexModel(ApplicationDbContext db)
      {
          this.db = db;
      }
      ```
    
      
    
