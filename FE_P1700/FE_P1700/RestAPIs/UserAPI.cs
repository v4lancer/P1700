using FE_P1700.DTOs;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace FE_P1700.RestAPIs
{
    /// <summary>
    /// Clase que proporciona métodos para interactuar con la API.
    /// </summary>
    public class UserAPI
    {
        private readonly string _apiBaseUrl; // URL base de la API.
        private readonly string _apiKeyName; // Nombre del encabezado de la clave API.
        private readonly string _apiKeyValue; // Valor de la clave API.


        /// <summary>
        /// Constructor que inicializa los valores de configuración de la API.
        /// </summary>
        /// <param name="options">Opciones de configuración que contienen la URL base y la clave API.</param>
        public UserAPI(IOptions<P1700ApiSettingsDto> options)
        {
            _apiBaseUrl = options.Value.ApiBaseUrl;
            _apiKeyName = options.Value.ApiKeyName;
            _apiKeyValue = options.Value.ApiKeyValue;
        }


        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>True si la creación fue exitosa; de lo contrario, false.</returns>
        public async Task<bool> RegistroAsync(RegistroDto usuario)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest($"User/Registrar", Method.Post);

            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(usuario);

            var response = await client.ExecuteAsync(request);

            return response.IsSuccessful ? true : false;
        }


        /// <summary>
        /// Valida el inicio de sesión
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns>Retorna el token como string</returns>
        public async Task<LoginResultDto> AutenticarAsync(LoginDto loginDto)
        {
            LoginResultDto loginResultDto = new LoginResultDto();
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("User/Autenticar", Method.Post);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(loginDto);

            var response = await client.ExecuteAsync(request);


            if (response.IsSuccessful)
            {
                var responseData = JsonConvert.DeserializeObject<dynamic>(response.Content);

                loginResultDto.IdPerfil = Convert.ToInt32(responseData.idPerfil);
                loginResultDto.Nombre = responseData.nombre;

                return loginResultDto;
            }

            return null;
        }


    }
}