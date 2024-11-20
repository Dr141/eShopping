using Modelo.Autenticacao.Enumerados;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Autenticacao.DTOs.Resquest;

public record UsuarioRoleRequest
{  
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Role Role { get; set; }

    public UsuarioRoleRequest(string email, Role role)
    {
        Email = email;
        Role = role;
    }
}
