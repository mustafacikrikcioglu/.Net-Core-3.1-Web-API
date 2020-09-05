using DapperForApi.LayerBusiness.InterfaceBusiness;
using DapperForApi.RequestResponse;
using DapperForApi.RequestResponse.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DapperForApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        private readonly IUrunBusiness _urunBusiness;

        public UrunController(IUrunBusiness urunBusiness)
        {
            _urunBusiness = urunBusiness;
        }

        // GET api/v1/Urun
        [HttpGet]
        public async Task<UrunResponse> GetAll()
        {
            return await _urunBusiness.GetAllAsync();
        }

        // GET api/v1/Urun/{id}
        [HttpGet("{id}")]
        public async Task<UrunResponse> Get(long id)
        {
            return await _urunBusiness.GetAsync(id);
        }

        // DELETE api/v1/Urun/{id}
        [ProducesResponseType(202)]
        [HttpDelete("{id}")]
        public async Task<UrunResponse> Delete(long id)
        {
            return await _urunBusiness.DeleteAsync(id);
        }

        // POST api/v1/Urun
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<UrunResponse> Post([FromBody] UrunRequest urunRequest)
        {
            return await _urunBusiness.AddAsync(urunRequest);
        }
    }
}