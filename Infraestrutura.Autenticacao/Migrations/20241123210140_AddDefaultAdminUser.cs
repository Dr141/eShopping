using Infraestrutura.Autenticacao.Contexto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

#nullable disable

namespace Infraestrutura.Autenticacao.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var adminRoleId = Guid.NewGuid().ToString();
            var adminUserId = Guid.NewGuid().ToString();
            var services = new ServiceCollection();

            // Add Identity services
            services.AddIdentityCore<IdentityUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<IdentityContexto>()
                    .AddDefaultTokenProviders();
            var serviceProvider = services.BuildServiceProvider();

            var passwordHasher = serviceProvider.GetRequiredService<IPasswordHasher<IdentityUser>>();
            var user = new IdentityUser { UserName = "admin@domain.com", Email = "admin@domain.com" };
            string passwordHash = passwordHasher.HashPassword(user, "Admin@123");

            migrationBuilder.Sql($@"
            INSERT INTO AspNetRoles (Id, Name, NormalizedName)
            VALUES ('{adminRoleId}', 'Administrador', 'ADMINISTRADOR');

            INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
            VALUES ('{adminUserId}', 'admin@domain.com', 'ADMIN', 'admin@domain.com', 'ADMIN@DOMAIN.COM', 1, '{passwordHash}', '{Guid.NewGuid().ToString()}', '{Guid.NewGuid().ToString()}', 0, 0, 1, 0);

            INSERT INTO AspNetUserRoles (UserId, RoleId)
            VALUES ('{adminUserId}', '{adminRoleId}');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetUserRoles WHERE UserId IN (SELECT Id FROM AspNetUsers WHERE UserName = 'admin')");
            migrationBuilder.Sql("DELETE FROM AspNetUsers WHERE UserName = 'admin'");
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE Name = 'Administrador'");
        }
    }
}
