using DapperForApi.Tablolar;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperForApi.LayerDal.InterfaceRepository
{
    public interface IKategoriRepository
    {
        Task<Kategori> GetAsync(long id);
        Task<IEnumerable<Kategori>> GetAllAsync();
        Task<int> AddAsync(Kategori kategori);
        Task<int> DeleteAsync(long id);
    }
}