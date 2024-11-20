using Microsoft.EntityFrameworkCore;
using AdvisorSystem.Data;
using AdvisorSystem.Services;

var builder = WebApplication.CreateBuilder(args);


// Configure the in-memory database 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("AdvisorDb")); 

// Register application services for Dependency Injection
builder.Services.AddScoped<IAdvisorService, AdvisorService>(); 

// Add controllers as services (API controllers)
builder.Services.AddControllers();

//add Swagger for API documentation (for development)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI only in development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
