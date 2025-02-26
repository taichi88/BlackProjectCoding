using Black.Application.ServiceContracts;
using Black.Infrastructure.Data;
using Black.Application;
using Black.Application.Services;
using Black.Domain.RepositoryContracts;
using Black.Infrastructure.Repositories;
using Black.Infrastructure.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DatabaseConnection service using the connection string from appsettings.json
builder.Services.AddSingleton<DatabaseConnection>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("BlackCodingConnectionString");
    return new DatabaseConnection(connectionString);
});

// Add DatabaseInitializer as Transient
builder.Services.AddTransient<DatabaseInitializer>();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICreatePersonService, CreatePersonService>();
builder.Services.AddScoped<ICreatePersonRepository, CreatePersonRepository>();
builder.Services.AddScoped<DapperHelper>();
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

var app = builder.Build();

// Execute Database Initialization Script after the app starts
using (var scope = app.Services.CreateScope())
{
    var databaseInitializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
    databaseInitializer.ExecuteScript();  // This will create the table in the DB
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
