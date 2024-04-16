using Microsoft.EntityFrameworkCore;
using GreenGardens.Model;
using GreenGardens.Data;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Retrieve the database connection string labeled "DefaultConnection" from the application's configuration settings.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register the DbContext for the application, specifying to use SQL Server with the connection string obtained earlier.
// AppDbContext is the class managing the database context.
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
//Register a singleton instance of product
builder.Services.AddSingleton<product>();
builder.Services.AddSingleton<admin>();
builder.Services.AddSingleton<order>();
builder.Services.AddSingleton<customer>();


builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        // Configure other options as needed
    });



// Register services for MVC Controllers and Views. This is essential for applications using the MVC architecture.
builder.Services.AddControllersWithViews();



// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Ensure this call is before UseAuthorization
app.UseAuthorization();

app.MapRazorPages();

app.Run();
