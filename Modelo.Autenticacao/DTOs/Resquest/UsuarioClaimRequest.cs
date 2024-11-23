using Modelo.Autenticacao.Enumerados;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Modelo.Autenticacao.DTOs.Resquest;

public class UsuarioClaimRequest
{    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ClaimTypes ClaimType { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ClaimValues ClaimValue { get; set; }

    public UsuarioClaimRequest(string email, ClaimTypes claimType, ClaimValues claimValue)
    {
        Email = email;
        ClaimValue = claimValue;
        ClaimType = claimType;
    }
}