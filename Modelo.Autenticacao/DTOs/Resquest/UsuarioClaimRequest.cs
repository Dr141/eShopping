using Modelo.Autenticacao.Enumerados;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Autenticacao.DTOs.Resquest;

public class UsuarioClaimRequest
{    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ClaimType ClaimType { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ClaimValue ClaimValue { get; set; }

    public UsuarioClaimRequest(string email, ClaimType claimType, ClaimValue claimValue)
    {
        Email = email;
        ClaimValue = claimValue;
        ClaimType = claimType;
    }
}