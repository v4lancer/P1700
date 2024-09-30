using API_P1700.Data;
using API_P1700.DTOs;
using API_P1700.Interfaces;
using API_P1700.Models;
using API_P1700.Utilidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API_P1700.Repositories
{
    //Inyección de la interfaz del repositorio
    public class UsuariosRepository : BaseRepository<Usuario>, IUsuariosRepository
    {
        //Inyección del context
        public UsuariosRepository(P1700Context context) : base(context) { }
        
        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            return await Context.Usuarios.Where(x=>x.Estado == true).ToListAsync();
        }
        
        public async Task<Usuario?> GetUsuarioById(int IdUsuario)
        {
            return await Context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);
        }

        public async Task<StoredProcedureDto?> MantenimientoUsuarios(UsuarioDto resource, int Accion)
        {
            Cifrado cifrado = new Cifrado();

            var paramIdUsuario = new SqlParameter("@ID_USUARIO", resource.IdUsuario);
            var paramCedula = new SqlParameter("@CEDULA", resource.Cedula);
            var paramContrasenia = new SqlParameter("@CONTRASENIA", cifrado.Encriptar(resource.Contrasenia));
            var paramIdPerfil = new SqlParameter("@ID_PERFIL", resource.IdPerfil);
            var paramCedulaInclusion = new SqlParameter("@CEDULA_INCLUSION", resource.CedulaInclusion);

            var paramAccion = new SqlParameter("@ACCION", Accion);

            var responseSp = await Context.Set<StoredProcedureDto>().FromSql($"EXECUTE [SP_MANTENIMIENTO_USUARIOS] {paramIdUsuario}, {paramCedula}, {paramContrasenia}, {paramIdPerfil}, {paramCedulaInclusion}, {paramAccion}").ToListAsync();

            return responseSp.FirstOrDefault();
        }


        public async Task<StoredProcedureDto?> Registrar(RegistroDto resource)
        {
            Cifrado cifrado = new Cifrado();

            var paramCedula = new SqlParameter("@CEDULA", resource.Cedula);
            var paramContrasenia = new SqlParameter("@CONTRASENIA", cifrado.Encriptar(resource.Contrasenia));
            var paramNombre = new SqlParameter("@NOMBRE", resource.Nombre);
            var paramIdPerfil = new SqlParameter("@ID_PERFIL", resource.IdPerfil);
            var paramIdTienda = new SqlParameter("@ID_TIENDA", resource.IdTienda);

            var responseSp = await Context.Set<StoredProcedureDto>().FromSql($"EXECUTE [SP_REGISTRAR_USUARIO] {paramCedula}, {paramContrasenia}, {paramNombre}, {paramIdPerfil}, {paramIdTienda}").ToListAsync();

            return responseSp.FirstOrDefault();
        }
    }
}
