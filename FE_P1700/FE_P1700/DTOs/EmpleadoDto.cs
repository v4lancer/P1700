using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FE_P1700.DTOs;

public partial class EmpleadoDto
{
    public int IdEmpleado { get; set; }

    [Required(ErrorMessage = "El nombre completo es requerido.")]
    [StringLength(100, ErrorMessage = "El nombre completo debe tener un máximo de 100 caracteres.")]
    public string Nombre { get; set; } = null!;

    [StringLength(20, ErrorMessage = "El télefono debe tener un máximo de 20 caracteres.")]
    public string? Telefono { get; set; }

    public decimal? Salario { get; set; }

    public bool? EsSupervisor { get; set; }

    public int IdUsuario { get; set; }

    public int IdTienda { get; set; }

    public bool? Estado { get; set; }

    public int? IdSupervisor { get; set; }

    public string? CedulaInclusion { get; set; }

}