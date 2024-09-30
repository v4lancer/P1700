using FE_P1700.DTOs;
using Microsoft.Extensions.Options;
using RestSharp;

namespace FE_P1700.RestAPIs
{

    /// <summary>
    /// Clase que proporciona métodos para interactuar con la API.
    /// </summary>
    public class EmpleadosAPI
    {
        private readonly string _apiBaseUrl; // URL base de la API.
        private readonly string _apiKeyName; // Nombre del encabezado de la clave API.
        private readonly string _apiKeyValue; // Valor de la clave API.

        /// <summary>
        /// Constructor que inicializa los valores de configuración de la API.
        /// </summary>
        /// <param name="options">Opciones de configuración que contienen la URL base y la clave API.</param>
        public EmpleadosAPI(IOptions<P1700ApiSettingsDto> options)
        {
            _apiBaseUrl = options.Value.ApiBaseUrl;
            _apiKeyName = options.Value.ApiKeyName;
            _apiKeyValue = options.Value.ApiKeyValue;
        }

        /// <summary>
        /// Obtiene una lista de todos los Empleados.
        /// </summary>
        /// <returns>Lista de objetos EmpleadosDto.</returns>
        public async Task<List<EmpleadoDto>> GetEmpleadosAsync()
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("Empleados", Method.Get);
            //request.AddHeader(_apiKeyName, pToken);

            var response = await client.ExecuteAsync<List<EmpleadoDto>>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }
            throw new Exception(response.StatusCode.ToString());
        }

        /// <summary>
        /// Obtiene un Empleado por su ID.
        /// </summary>
        /// <param name="id">ID del Empleado.</param>
        /// <returns>Objeto empleadoDto correspondiente al ID proporcionado.</returns>
        public async Task<EmpleadoDto> GetEmpleadoAsync(int id)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest($"Empleados/{id}", Method.Get);
            //request.AddHeader(_apiKeyName, pToken);

            var response = await client.ExecuteAsync<EmpleadoDto>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }
            throw new Exception(response.ErrorMessage);
        }

        /// <summary>
        /// Actualiza la información de un Empleado existente.
        /// </summary>
        /// <param name="empleadoDto">Datos actualizados del Empleado.</param>
        /// <returns>True si la actualización fue exitosa; de lo contrario, false.</returns>
        public async Task<bool> PutEmpleadoAsync(EmpleadoDto empleadoDto)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("Empleados", Method.Put);
            //request.AddHeader(_apiKeyName, pToken);
            request.AddJsonBody(empleadoDto);

            var response = await client.ExecuteAsync(request);

            return response.IsSuccessful;

        }

        /// <summary>
        /// Crea un nuevo Empleado.
        /// </summary>
        /// <param name="empleadoDto">Datos del nuevo Empleado.</param>
        /// <returns>True si la creación fue exitosa; de lo contrario, false.</returns>
        public async Task<bool> PostEmpleadoAsync(EmpleadoDto empleadoDto)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("Empleados", Method.Post);
            //request.AddHeader(_apiKeyName, pToken);
            request.AddJsonBody(empleadoDto);

            var response = await client.ExecuteAsync(request);

            return response.IsSuccessful;
        }

        /// <summary>
        /// Elimina un Empleado por su ID.
        /// </summary>
        /// <param name="id">ID del Empleado a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa; de lo contrario, false.</returns>
        public async Task<bool> DeleteEmpleadoAsync(int id)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest($"Empleados/{id}", Method.Delete);
            //request.AddHeader(_apiKeyName, pToken);

            var response = await client.ExecuteAsync(request);

            return response.IsSuccessful;
        }

    }
}
