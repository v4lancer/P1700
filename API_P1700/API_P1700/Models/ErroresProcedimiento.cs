using System;
using System.Collections.Generic;

namespace API_P1700.Models;

public partial class ErroresProcedimiento
{
    public long IdErrorProcedimiento { get; set; }

    public short? Bloque { get; set; }

    public int? NumeroError { get; set; }

    public int? Importancia { get; set; }

    public int? Estado { get; set; }

    public string? Procedimiento { get; set; }

    public int? Linea { get; set; }

    public string? MensajeBd { get; set; }

    public string? Mensaje { get; set; }

    public DateOnly FechaInclusion { get; set; }

    public string CedulaInclusion { get; set; } = null!;
}
