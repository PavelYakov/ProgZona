using Auth.JwtAuthManager;
using Microsoft.EntityFrameworkCore;
using Product.Data.Context;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomJwtAuthentication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection"));
    options.UseSqlServer("Server=Yakovbook\\SQLEXPRESS;Database=ProductProgZona;User Id=sa;Password=sa;TrustServerCertificate=True;");


});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();