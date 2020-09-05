using DapperForApi.RequestResponse;
using DapperForApi.RequestResponse.Request;
using System.Threading.Tasks;

namespace DapperForApi.LayerBusiness.InterfaceBusiness
{
    public interface IKategoriBusiness
    {
        Task<KategoriResponse> GetAsync(long id);
        Task<KategoriResponse> GetAllAsync();
        Task<KategoriResponse> AddAsync(KategoriRequest kategoriRequest);
        Task<KategoriResponse> DeleteAsync(long id);
    }
}