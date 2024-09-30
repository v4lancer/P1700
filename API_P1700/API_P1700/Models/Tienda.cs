using System;
using System.Collections.Generic;

namespace API_P1700.Models;

public partial class Tienda
{
    public int IdTienda { get; set; }

    public string Tienda1 { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateOnly FechaInclusion { get; set; }

    public string CedulaInclusion { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
