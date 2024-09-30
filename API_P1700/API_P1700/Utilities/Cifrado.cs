namespace API_P1700.Utilidades
{
    public class Cifrado
    {

        /// <summary>
        /// Cifrado de contraseña
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public string Encriptar(string cadena) => BCrypt.Net.BCrypt.HashPassword(cadena);

        /// <summary>
        /// Desencriptar contraseña
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public bool Desencriptar(string cadena, string hashedContrasenia) => BCrypt.Net.BCrypt.Verify(cadena, hashedContrasenia);

    }
}
