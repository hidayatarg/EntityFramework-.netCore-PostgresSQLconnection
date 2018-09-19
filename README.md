# .Net Core Entity Framework with PostgreSQL Code First

# PostgreSQL
PostgreSQL is a powerful, open source object-relational database system that uses and extends the SQL language combined with many features that safely store and scale the most complicated data workloads.

During developing this repository I am working in GIS software company. My company use PostgreSQL for saving geometric coordinates of the objects.

# .Net
.NET is a free, cross-platform, open source developer platform for building many different types of applications.With .NET, you can use multiple languages, editors, and libraries to build for web, mobile, desktop, gaming, and IoT


# IDE's
I will show you how to implement this project in
  - Visual Studio 2017
  - Visual Studio code 
  
> These days visual studio code is very famous in open-source community
## Implementing the Project using visal studio 
Steps:
  - Creating new Project choose ASP.net Core Web Application (I named it as Ef6CoreForPostgreSQL)
  - Choose API from the next window
  - Export documents as Markdown, HTML and PDF
  - Right click on Project Solution select Manage Nuget Package and Install the following packages
    -  Npgsql.EntityFrameworkCore.PostgreSQL
    -  Microsoft.EntityFrameworkCore.Design
    -  Microsoft.EntityFrameworkCore.Tools

After the Installation, go to Startup.cs. In the ConfigureServices method we need to add PostgreSQL to the project
Add your Database context (in my case MyWebApiContext) and the connection string name (ConnectionString is added in appsettings.json) (in my case MyWebApiConection).

```sh
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    services.AddEntityFrameworkNpgsql().AddDbContext<MyWebApiContext>(opt =>
        opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConection")));
}
```

In the appsetting.json,
We write PostgreSQL user id, password, server, port and the database name that will be created by code first.
```sh
  "ConnectionStrings": {
    "MyWebApiConection": "User ID =postgres;Password=hp;Server=localhost;Port=5430;Database=deneme; 
    Integrated Security=true;Pooling=true;"
 ```

Connection string is added in the top of the appsettings.json, (Complete view of appsetting.json)
```sh
{
  "ConnectionStrings": {
    "MyWebApiConection": "User ID =postgres;Password=hp;Server=localhost;Port=5430;Database=deneme;Integrated Security=true;Pooling=true;"
  },
  "Logging": {
    "IncludeScopes": false,
    "Debug": {
      "LogLevel": {
        "Default": "Warning"
      }
    },
    "Console": {
      "LogLevel": {
        "Default": "Warning"
      }
    }
  }
}
```
Create a folder and name it models, Add the models:

Group.cs
```sh
public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

User.cs
```sh
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    // from the group model (Entity framework will connect the Primarykey and forign key)
    public Group Group { get; set; }
    public int GroupId { get; set; }
}
```
Now, Create a DbContext (In my case I named it as MyWebApiContext). This database context is inherited from the DbContext.
> DbContext error: check the entityFramework it may not be installed.

MyWebApiContext  > Database context name is add in the constructor. 
```sh
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Ef6CoreForPosgreSQL.Models
{
    public class MyWebApiContext:DbContext
    {
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options):base(options) {  }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
 ```
 

### Start the Project
Open Package Manager Console
```sh
PM> enable-migrations
```
```sh
PM> add-migration initial
```
```sh
PM> update-database
```
### For Visual Studio Code 

![N|Solid| width=5 ](https://code.visualstudio.com/assets/blogs/2017/10/24/blueicon.png)
Coming Soon



### About me
For any question and technical help with the repository, feel free to contact me via: 

Email: hidayatarg@gmail.com

[![N|Solid| width=5 ](https://image.ibb.co/dzZczz/Webp_net_resizeimage.png)](https://www.linkedin.com/in/hidayatarg/)Linkedin Profile
