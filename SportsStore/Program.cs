using Microsoft.EntityFrameworkCore;
using SportsStore.Data.Context;
using SportsStore.Data.Repositories.Abstract;
using SportsStore.Data.Repositories.Concrete;
using SportsStore.Data.Seed;
using SportsStore.Models;

// Creates a new web application builder, providing a convenient entry point for configuring and building an ASP.NET web application.
var builder = WebApplication.CreateBuilder(args);

// Adds the MVC services to the application.
builder.Services.AddControllersWithViews();

// Configures the application to use the database defined in the ConnectionStrings section of the appsettings.json file.
builder.Services.AddDbContext<StoreDbContext>(opts =>
    {
        opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
    }
);

// Registers the EfStoreRepository class as the service that will be used to satisfy requests for IStoreRepository objects.
builder.Services.AddScoped<IStoreRepository, EfStoreRepository>();

// Registers the EfOrderRepository class as the service that will be used to satisfy requests for IOrderRepository objects.
builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();

// Adds Razor Pages services to the application, enabling the use of dynamic web pages with embedded C# code (Razor syntax).
builder.Services.AddRazorPages();

// Registers the distributed memory cache service, enabling efficient storage of session data in-memory.
builder.Services.AddDistributedMemoryCache();

// Registers the session service, configuring it to use the distributed memory cache for storing session information.
builder.Services.AddSession();

// Registers the Cart class as a scoped service, indicating that a new instance will be created for each scope (typically per request). 
// The service provider will use the provided lambda expression to instantiate Cart objects, utilizing the SessionCart class through the GetCart method.
builder.Services.AddScoped(SessionCart.GetCart);

// Registers the HttpContextAccessor class as a singleton service, indicating that a single instance will be created for the lifetime of the application.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Configures and adds Server-Side Blazor services to the DI container.
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Enables serving static files (e.g., CSS, JavaScript, images) to clients, allowing access to resources in the 'wwwroot' folder.
app.UseStaticFiles();

app.MapControllerRoute("category-page",
    "{category}/Page{productPage:int}",
    new { Controller = "Home", action = "Index" });

app.MapControllerRoute("category", "{category}",
    new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute("pagination",
    "Products/Page{productPage}",
    new { Controller = "Home", action = "Index", productPage = 1 });

// Maps the default controller route, providing a default route for MVC controllers. (/Controller/Action/Id)
app.MapDefaultControllerRoute();

// Maps Razor Pages, allowing the application to respond to Razor Page requests.
app.MapRazorPages();

// Map the Blazor Hub endpoint to enable real-time communication between the server and Blazor components.
app.MapBlazorHub();

// MapFallbackToPage is used to specify a fallback page for certain routes.
// In this case, any URL starting with "/admin/" will fall back to the "/Admin/Index" page.
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

// Enables session support in the application, allowing the storage and retrieval of user-specific data during the user's session.
app.UseSession();

SeedData.EnsurePopulated(app);

// Runs the configured web application, starting the server to listen for incoming requests and handle them based on the defined routes and configurations.
app.Run();