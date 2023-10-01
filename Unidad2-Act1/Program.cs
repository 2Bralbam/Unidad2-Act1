using Unidad2_Act1.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddDbContext<ZooplanetContext>();

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStaticFiles();
app.Run();
