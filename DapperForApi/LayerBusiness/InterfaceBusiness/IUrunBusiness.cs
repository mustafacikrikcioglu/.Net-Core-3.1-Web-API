using DapperForApi.RequestResponse;
using DapperForApi.RequestResponse.Request;
using System.Threading.Tasks;

namespace DapperForApi.LayerBusiness.InterfaceBusiness
{
    public interface IUrunBusiness
    {
        Task<UrunResponse> GetAsync(long id);
        Task<UrunResponse> GetAllAsync();
        Task<UrunResponse> AddAsync(UrunRequest urunRequest);
        Task<UrunResponse> DeleteAsync(long id);
    }
}