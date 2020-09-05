using DapperForApi.Tablolar;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperForApi.LayerDal.InterfaceRepository
{
    public interface IUrunRepository
    {
        Task<Urun> GetAsync(long id);
        Task<IEnumerable<Urun>> GetAllAsync();
        Task<int> AddAsync(Urun urun);
        Task<int> DeleteAsync(long id);
    }
}