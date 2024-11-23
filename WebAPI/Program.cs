using WebAPI.Extensoes;
using WebAPI.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigAuthentication(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.Services.Migrations();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
