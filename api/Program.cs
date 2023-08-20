using Microsoft.EntityFrameworkCore;
using persistence;
using persistence.Materials;

/**************************************
* Configuration and setup
***************************************/
var builder = WebApplication.CreateBuilder(args);

/**************************************
 * Services
 **************************************/
builder.Services.AddControllers(); // Adding controller services
builder.Services.AddEndpointsApiExplorer(); // Adding the API Explorer service
builder.Services.AddSwaggerGen(); // Adding the SwaggerGen service

/**************************************
* Setting up AutoMapper
***************************************/
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // Adding AutoMapper services

/**************************************
* Dependency Injection
***************************************/
builder.Services.AddScoped<IConcreteRepository, ConcreteRepository>();

/**************************************
 * Enable CORS for specified origins / all origins
 **************************************/
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});

/**************************************
 * Configuring the Database
 **************************************/
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

/**************************************
 * Application Setup
 **************************************/
var app = builder.Build();

/**************************************
 * Database automatic migration and seeding if no DB exists
 **************************************/
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>(); // Retrieving the DataContext
    await context.Database.MigrateAsync(); // Migrating the database automatically
    await Seed.SeedData(context); // Seed the DB
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger>();
    logger.LogError(ex, "An error occurred during migration");
}

/******************************************
* Configuring the HTTP request pipeline
******************************************/
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Adding Swagger middleware
    app.UseSwaggerUI(); // Adding Swagger UI middleware
}

app.UseHttpsRedirection(); // HTTPS redirection
app.UseCors("CorsPolicy"); // Use the CORS policy defiend earlier
app.UseAuthorization(); // Authorization middleware
app.MapControllers(); // Map controller routes
await app.RunAsync();  // Run the application, needs to be async in case the DB automatically migrates