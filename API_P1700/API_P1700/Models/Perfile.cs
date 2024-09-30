using System;
using System.Collections.Generic;

namespace API_P1700.Models;

public partial class Perfile
{
    public int IdPerfil { get; set; }

    public string Perfil { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateOnly FechaInclusion { get; set; }

    public string CedulaInclusion { get; set; } = null!;

    public virtual ICollection<PermisosPerfile> PermisosPerfiles { get; set; } = new List<PermisosPerfile>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
