using API_P1700.Data;
using API_P1700.DTOs;
using API_P1700.Interfaces;
using API_P1700.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API_P1700.Repositories
{
    //Inyección de la interfaz del repositorio
    public class EmpleadosRepository : BaseRepository<Empleado>, IEmpleadosRepository
    {
        //Inyección del context
        public EmpleadosRepository(P1700Context context) : base(context) { }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await Context.Empleados.Where(x=>x.Estado == true).ToListAsync();
        }

        public async Task<Empleado?> GetEmpleadoById(int IdEmpleado)
        {
            return await Context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == IdEmpleado);
        }

        public async Task<StoredProcedureDto?> MantenimientoEmpleados(EmpleadoDto resource, int Accion)
        {
            var paramIdEmpleado = new SqlParameter("@ID_EMPLEADO", resource.IdEmpleado);
            var paramNombre = new SqlParameter("@NOMBRE", resource.Nombre);
            var paramTelefono = new SqlParameter("@TELEFONO", resource.Telefono);
            var paramSalario = new SqlParameter("@SALARIO", resource.Salario);
            var paramEsSupervisor = new SqlParameter("@ES_SUPERVISOR", resource.EsSupervisor);
            var paramIdUsuario = new SqlParameter("@ID_USUARIO", resource.IdUsuario);
            var paramTienda = new SqlParameter("@ID_TIENDA", resource.IdTienda);
            var paramIdSupervisor = new SqlParameter("@ID_SUPERVISOR", resource.IdSupervisor);
            var paramCedulaInclusion = new SqlParameter("@CEDULA_INCLUSION", resource.CedulaInclusion == null ? "" : resource.CedulaInclusion);

            var paramAccion = new SqlParameter("@ACCION", Accion);

            var responseSp = await Context.Set<StoredProcedureDto>().FromSql($"EXECUTE [SP_MANTENIMIENTO_EMPLEADOS] {paramIdEmpleado}, {paramNombre}, {paramTelefono}, {paramSalario}, {paramEsSupervisor}, {paramIdUsuario}, {paramTienda}, {paramIdSupervisor}, {paramCedulaInclusion}, {paramAccion}").ToListAsync();

            return responseSp.FirstOrDefault();
        }
    }
}
