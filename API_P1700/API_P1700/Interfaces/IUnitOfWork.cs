namespace API_P1700.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Referencia a la interface de Empleados
        /// </summary>
        IEmpleadosRepository Empleados { get; }

        /// <summary>
        /// Referencia a la interface de Usuarios
        /// </summary>
        IUsuariosRepository Usuarios { get; }

        /// <summary>
        /// Referencia a la interface de Perfiles
        /// </summary>
        IPerfilesRepository Perfiles { get; }

        /// <summary>
        /// Referencia a la interface de Tiendas
        /// </summary>
        ITiendasRepository Tiendas { get; }


        /// <summary>
        /// Para guardar cambios en BD
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}
