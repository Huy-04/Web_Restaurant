using Common.Behaviors;
using Common.Middleware;
using MediatR;
using Menu.Application.Interfaces;
using Menu.Application.Modules.FoodTypes.Commands.CreateFoodType;
using Menu.Infrastructure.Persistence;
using Menu.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Add OpenAPI endpoints explorer
builder.Services.AddEndpointsApiExplorer();

// Cấu hình Swagger/OpenAPI chi tiết
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Menu API",
        Version = "v1",
        Description = "API for managing food types",
        Contact = new OpenApiContact
        {
            Name = "Developer Team",
            Email = "developer@example.com",
            Url = new Uri("https://example.com")
        }
    });
});

// Đăng ký DbContext
builder.Services.AddDbContext<MenuDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("MenuDatabase");
    options.UseSqlServer(cs);
});

// Đăng ký repository & UnitOfWork
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IFoodTypeRepository, FoodTypeRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Đăng ký MediatR và behaviors
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateFoodTypeCommand).Assembly);
});
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviors<,>));

// Build app
var app = builder.Build();

// Cấu hình middleware
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();