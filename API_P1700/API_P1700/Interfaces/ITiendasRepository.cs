using API_P1700.Models;

namespace API_P1700.Interfaces
{
    public interface ITiendasRepository : IBaseRepository<Tienda>
    {
        Task<List<Tienda>> GetTiendasAsync();

        Task<Tienda?> GetTiendaById(int autorId);
    }
}
