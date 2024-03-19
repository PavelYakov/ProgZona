using JwtAuthManager;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<JwtTokenHandler>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseAuthorization();
app.MapControllers();
app.Run();