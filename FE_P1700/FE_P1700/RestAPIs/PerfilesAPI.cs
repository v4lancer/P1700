using FE_P1700.DTOs;
using Microsoft.Extensions.Options;
using RestSharp;

namespace FE_P1700.RestAPIs
{
    /// <summary>
    /// Clase que proporciona métodos para interactuar con la API.
    /// </summary>
    public class PerfilesAPI
    {
        private readonly string _apiBaseUrl; // URL base de la API.
        private readonly string _apiKeyName; // Nombre del encabezado de la clave API.
        private readonly string _apiKeyValue; // Valor de la clave API.


        /// <summary>
        /// Constructor que inicializa los valores de configuración de la API.
        /// </summary>
        /// <param name="options">Opciones de configuración que contienen la URL base y la clave API.</param>
        public PerfilesAPI(IOptions<P1700ApiSettingsDto> options)
        {
            _apiBaseUrl = options.Value.ApiBaseUrl;
            _apiKeyName = options.Value.ApiKeyName;
            _apiKeyValue = options.Value.ApiKeyValue;
        }

        /// <summary>
        /// Obtiene una lista de todos los Perfiles.
        /// </summary>
        /// <returns>Lista de objetos PerfileDto.</returns>
        public async Task<List<PerfileDto>> GetPerfilesAsync()
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("Perfiles", Method.Get);
            //request.AddHeader(_apiKeyName, pToken);

            var response = await client.ExecuteAsync<List<PerfileDto>>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }
            throw new Exception(response.StatusCode.ToString());
        }

    }
}
