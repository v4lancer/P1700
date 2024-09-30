using API_P1700.Data;
using API_P1700.Interfaces;

namespace API_P1700.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly P1700Context _context;

        private IEmpleadosRepository _empleados = default!;
        private IUsuariosRepository _usuarios = default!;
        private IPerfilesRepository _perfiles = default!;
        private ITiendasRepository _tiendas = default!;

        public IEmpleadosRepository Empleados => _empleados ?? new EmpleadosRepository(_context);
        public IUsuariosRepository Usuarios => _usuarios ?? new UsuariosRepository(_context);
        public IPerfilesRepository Perfiles => _perfiles ?? new PerfilesRepository(_context);
        public ITiendasRepository Tiendas => _tiendas ?? new TiendasRepository(_context);


        public UnitOfWork(P1700Context context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
