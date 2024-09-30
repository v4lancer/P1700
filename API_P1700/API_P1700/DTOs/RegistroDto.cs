using System.ComponentModel.DataAnnotations;

namespace API_P1700.DTOs
{
    public class RegistroDto
    {
        [Required(ErrorMessage = "La cédula es requerida.")]
        public string Cedula { get; set; } = null!;

        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Contrasenia { get; set; } = null!;

        [Required(ErrorMessage = "El nombre completo es requerido.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El perfil es requerido.")]
        public int IdPerfil { get; set; }

        [Required(ErrorMessage = "La tienda es requerido.")]
        public int IdTienda { get; set; }
    }
}
