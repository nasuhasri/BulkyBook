// program that responsible in running the application
// contains code to start the server, listen for incoming requests, code to configure the application

// CreateBuilder set up Kestrel web server, configure IIS integration, specify content root, read
// application settings from appsettings.json
// Kestrel is built-in cross platform server, run as part of our application and handle the requests
// is placed behind a real web server like IIS where it is a windows server
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // example of middleware
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
