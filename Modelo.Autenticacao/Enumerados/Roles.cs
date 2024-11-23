using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Modelo.Autenticacao.Enumerados;

[JsonConverter(typeof(StringEnumConverter))]
public enum Roles
{    
    Administrador,
    Administrativo,
    Auxiliar,
    Gerente,
    Vendedor
}
