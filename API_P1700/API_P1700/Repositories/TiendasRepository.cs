using API_P1700.Data;
using API_P1700.Interfaces;
using API_P1700.Models;
using Microsoft.EntityFrameworkCore;

namespace API_P1700.Repositories
{
    public class TiendasRepository : BaseRepository<Tienda>, ITiendasRepository
    {
        //Inyección del context
        public TiendasRepository(P1700Context context) : base(context) { }

        public async Task<List<Tienda>> GetTiendasAsync()
        {
            return await Context.Tiendas.Where(x=>x.Estado == true).ToListAsync();
        }

        public async Task<Tienda?> GetTiendaById(int IdTienda)
        {
            return await Context.Tiendas.FirstOrDefaultAsync(x => x.IdTienda == IdTienda);
        }
    }
}
