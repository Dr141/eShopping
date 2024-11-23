using Modelo.Autenticacao.Enumerados;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Modelo.Autenticacao.DTOs.Resquest;

public record UsuarioRoleRequest
{  
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]    
    public Roles Role { get; set; }

    public UsuarioRoleRequest(string email, Roles role)
    {
        Email = email;
        Role = role;
    }
}
