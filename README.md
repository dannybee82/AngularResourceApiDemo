### **Angular 19 Resource API Demo + .NET/C# WebAPI + PostgreSQL database**

A demo that demonstrates the new **Angular 19** _Resource API_.  
It uses a simple .NET/C# WebAPI as Backend and a PostgreSQL database.

The Angular application uses interfaces and abstract classes to reduce the amount of code.   
See the images in the root of this project for examples.

### **PostgreSQL database:**

See the folder: _Docker\_PostgreSQL\_database_ with the docker-compose file.

Command to add the _docker container_:

**docker-compose up --build -d**

### **Add database migrations**

Install the **dotnet ef-tool** - version: 8.0.11 or above

When the tool is installed, run the command for a _database migration:_

**dotnet ef database update**

For more information see the link below:

[https://learn.microsoft.com/en-us/ef/core/cli/dotnet](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

### **Angular application installation**

**Command to install**

_npm install_

or shorter:

_npm i_

**Command to run the application:**

_ng serve --open_

or shorter:

_ng s --o_