using System;
using System.Collections.Generic;

namespace API_P1700.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Cedula { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public int IdPerfil { get; set; }

    public bool? Estado { get; set; }

    public DateTime FechaInclusion { get; set; }

    public string CedulaInclusion { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Perfile IdPerfilNavigation { get; set; } = null!;
}
