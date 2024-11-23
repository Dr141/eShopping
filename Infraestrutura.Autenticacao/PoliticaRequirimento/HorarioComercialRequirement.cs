using Microsoft.AspNetCore.Authorization;

namespace Infraestrutura.Autenticacao.PoliticaRequirimento;

public class HorarioComercialRequirement : IAuthorizationRequirement
{
    public HorarioComercialRequirement() { }
}
