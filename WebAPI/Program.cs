using Microsoft.Extensions.Options;
using WebAPI.Extensoes;
using WebAPI.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigAuthentication(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new()
        {
            Title = "Autenticação API",
            Version = "v1",
            Description = "API para autenticar usuários."
        };
        return Task.CompletedTask;
    });
});

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
