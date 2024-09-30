namespace API_P1700.DTOs
{
    public class PerfileDto
    {
        public int IdPerfil { get; set; }

        public string Perfil { get; set; } = null!;

        public string? Descripcion { get; set; }

        public bool? Estado { get; set; }
    }
}
