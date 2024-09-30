using System;
using System.Collections.Generic;

namespace API_P1700.Models;

public partial class EmpleadosVistum
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateOnly FechaInclusion { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal? Salario { get; set; }

    public int IdSupervisor { get; set; }

    public string Supervisor { get; set; } = null!;
}
