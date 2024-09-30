using API_P1700.DTOs;
using API_P1700.Models;

namespace API_P1700.Interfaces
{
    public interface IEmpleadosRepository : IBaseRepository<Empleado>
    {
        Task<List<Empleado>> GetEmpleadosAsync();

        Task<Empleado?> GetEmpleadoById(int autorId);

        Task<StoredProcedureDto?> MantenimientoEmpleados(EmpleadoDto resource, int Accion);
    }
}
