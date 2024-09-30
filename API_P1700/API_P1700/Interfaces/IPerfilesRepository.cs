using API_P1700.Models;

namespace API_P1700.Interfaces
{
    public interface IPerfilesRepository : IBaseRepository<Perfile>
    {

        Task<List<Perfile>> GetPerfilesAsync();

        Task<Perfile?> GetPerfilById(int autorId);
    }
}
