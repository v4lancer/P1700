using System;
using System.Collections.Generic;

namespace FE_P1700.DTOs;

public partial class UsuarioDto
{
    public int IdUsuario { get; set; }

    public string Cedula { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public int IdPerfil { get; set; }

    public bool? Estado { get; set; }

    public string CedulaInclusion { get; set; } = null!;

}
