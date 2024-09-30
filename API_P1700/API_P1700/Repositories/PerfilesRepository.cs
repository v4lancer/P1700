using API_P1700.Data;
using API_P1700.Interfaces;
using API_P1700.Models;
using Microsoft.EntityFrameworkCore;

namespace API_P1700.Repositories
{
    public class PerfilesRepository : BaseRepository<Perfile>, IPerfilesRepository
    {
        //Inyección del context
        public PerfilesRepository(P1700Context context) : base(context) { }

        public async Task<List<Perfile>> GetPerfilesAsync()
        {
            return await Context.Perfiles.Where(x=>x.Estado == true).ToListAsync();
        }

        public async Task<Perfile?> GetPerfilById(int IdPerfil)
        {
            return await Context.Perfiles.FirstOrDefaultAsync(x => x.IdPerfil == IdPerfil);
        }
    }
}
