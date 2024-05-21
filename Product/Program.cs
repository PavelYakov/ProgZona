using Auth.JwtAuthManager;
using Microsoft.EntityFrameworkCore;
using Product.Contracts.Course;
using Product.Contracts.MainCourse;
using Product.Contracts.Stage;
using Product.Contracts.User;
using Product.Data.Context;
using Product.Services.CourseService;
using Product.Services.MainCourseService;
using Product.Services.StageService;
using Product.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomJwtAuthentication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMainCourseReader, MainCourseReader>();
builder.Services.AddScoped<IUserReader, UserReader>();
builder.Services.AddScoped<ICourseReader, CourseReader>();
builder.Services.AddScoped<IStageReader, StageReader>();
//builder.Services.AddScoped<MainCourseReader>();


builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection"));
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