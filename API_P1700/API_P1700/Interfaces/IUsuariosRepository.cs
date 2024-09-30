using API_P1700.DTOs;
using API_P1700.Models;

namespace API_P1700.Interfaces
{
    public interface IUsuariosRepository : IBaseRepository<Usuario>
    {
        Task<List<Usuario>> GetUsuariosAsync();

        Task<Usuario?> GetUsuarioById(int autorId);

        Task<StoredProcedureDto?> MantenimientoUsuarios(UsuarioDto resource, int Accion);

        Task<StoredProcedureDto?> Registrar(RegistroDto resource);
    }
}
