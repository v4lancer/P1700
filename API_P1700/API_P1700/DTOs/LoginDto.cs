using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace API_P1700.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "La cédula es requerida.")]
        [StringLength(20, ErrorMessage = "La cédula debe tener un máximo de 20 caracteres.")]
        public string Cedula { get; set; } = null!;

        [PasswordPropertyText]
        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(100, ErrorMessage = "La contraseña debe tener un máximo de 100 caracteres.")]
        public string Contrasenia { get; set; } = null!;
    }
}
