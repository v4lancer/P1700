using System;
using System.Collections.Generic;

namespace API_P1700.Models;

public partial class PermisosPerfile
{
    public int IdPermisoPerfil { get; set; }

    public int IdPerfil { get; set; }

    public int IdPermiso { get; set; }

    public DateOnly FechaInclusion { get; set; }

    public virtual Perfile IdPerfilNavigation { get; set; } = null!;

    public virtual Permiso IdPermisoNavigation { get; set; } = null!;
}
