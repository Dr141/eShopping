using Infraestrutura.Autenticacao.Contexto;
using Infraestrutura.Autenticacao.Servicos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modelo.Autenticacao.Interfaces.Servicos;

namespace WebAPI.IoC;

public static class RegistrarDependencias
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityContexto>(options =>
            options.UseSqlServer(configuration.GetConnectionString("eShoppingConection"))
        );

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityContexto>()
            .AddDefaultTokenProviders();

        services.AddScoped<IIdentityService, IdentityService>();
    }

    public static void Migrations(this IServiceProvider service)
    {
        using (var scope = service.CreateScope())
        {
            var dbAppIdentity = scope.ServiceProvider.GetRequiredService<IdentityContexto>();
            dbAppIdentity.Database.Migrate();
        }
    }
}
