using System.ComponentModel.DataAnnotations;

namespace Modelo.Autenticacao.DTOs.Resquest;

public record UsuarioPermisaoRequest
{  
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public List<string> Permissoes { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public bool EhClaims { get; set; } = false;

    public UsuarioPermisaoRequest(string email, List<string> permissoes, bool ehClaims)
    {
        Email = email;
        Permissoes = permissoes;
        EhClaims = ehClaims;
    }
}
