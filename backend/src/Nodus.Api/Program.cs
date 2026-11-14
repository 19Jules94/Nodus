using Nodus.Application;
using Nodus.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// HTTP Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();