using System;
using System.Collections.Generic;

namespace API_P1700.DTOs;

public partial class EmpleadoDto
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public decimal? Salario { get; set; }

    public bool? EsSupervisor { get; set; }

    public int IdUsuario { get; set; }

    public int IdTienda { get; set; }

    public bool? Estado { get; set; }

    public int? IdSupervisor { get; set; }

    public string? CedulaInclusion { get; set; }

}