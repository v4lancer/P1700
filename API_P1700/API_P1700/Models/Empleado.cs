using System;
using System.Collections.Generic;

namespace API_P1700.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public decimal? Salario { get; set; }

    public bool? EsSupervisor { get; set; }

    public int IdUsuario { get; set; }

    public int IdTienda { get; set; }

    public bool? Estado { get; set; }

    public DateOnly FechaInclusion { get; set; }

    public string? CedulaInclusion { get; set; }

    public int? IdSupervisor { get; set; }

    public virtual Empleado? IdSupervisorNavigation { get; set; }

    public virtual Tienda IdTiendaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Empleado> InverseIdSupervisorNavigation { get; set; } = new List<Empleado>();
}
