﻿using Microsoft.AspNetCore.Authorization;

namespace Infraestrutura.Autenticacao.PoliticaRequirimento;

public class HorarioComercialHandler : AuthorizationHandler<HorarioComercialRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HorarioComercialRequirement requirement)
    {
        var horarioAtual = TimeOnly.FromDateTime(DateTime.Now);
        if (horarioAtual.Hour >= 8 && horarioAtual.Hour <= 18)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
