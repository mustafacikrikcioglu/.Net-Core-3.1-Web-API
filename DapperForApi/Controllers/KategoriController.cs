using DapperForApi.LayerBusiness.InterfaceBusiness;
using DapperForApi.RequestResponse;
using DapperForApi.RequestResponse.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DapperForApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriBusiness _kategoriBusiness;

        public KategoriController(IKategoriBusiness kategoriBusiness)
        {
            _kategoriBusiness = kategoriBusiness;
        }

        // GET api/v1/Kategori
        [HttpGet]
        public async Task<KategoriResponse> GetAll()
        {
            return await _kategoriBusiness.GetAllAsync();
        }

        // GET api/v1/Kategori/{id}
        [HttpGet("{id}")]
        public async Task<KategoriResponse> Get(long id)
        {
            return await _kategoriBusiness.GetAsync(id);
        }

        // DELETE api/v1/Kategori/{id}
        [ProducesResponseType(202)]
        [HttpDelete("{id}")]
        public async Task<KategoriResponse> Delete(long id)
        {
            return await _kategoriBusiness.DeleteAsync(id);
        }

        // POST api/v1/Kategori
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<KategoriResponse> Post([FromBody] KategoriRequest kategoriRequest)
        {
            return await _kategoriBusiness.AddAsync(kategoriRequest);
        }
    }
}