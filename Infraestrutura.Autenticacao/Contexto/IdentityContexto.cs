using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Autenticacao.Contexto;

public class IdentityContexto : IdentityDbContext
{
    public IdentityContexto(DbContextOptions<IdentityContexto> options) : base(options)
    {   
    }
}
