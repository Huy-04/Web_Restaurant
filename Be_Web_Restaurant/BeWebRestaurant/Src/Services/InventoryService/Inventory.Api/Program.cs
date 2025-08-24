using Inventory.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InventoryDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("InventoryDatabase");
    options.UseSqlServer(cs);
});

var app = builder.Build();

app.Run();