# .NET Core with Razor
Simple .NET Core project using Razor pages with Entity framework.

## Definition
Basic example of a web project created with .NET Core. 
Hope this example help others as point of reference to start learning programming with .NET Core.

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

## Basic Concepts

- Routing
  - Maps URL's to Physical file on disk. 
  - Needs a root folder
  - Index.cshtml is a default document

## Creating our project.
1. 
