using System;
using System.Collections.Generic;

namespace API_P1700.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string Permiso1 { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateOnly FechaInclusion { get; set; }

    public string CedulaInclusion { get; set; } = null!;

    public virtual ICollection<PermisosPerfile> PermisosPerfiles { get; set; } = new List<PermisosPerfile>();
}
