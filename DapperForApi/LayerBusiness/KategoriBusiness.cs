using DapperForApi.LayerBusiness.InterfaceBusiness;
using DapperForApi.LayerDal.InterfaceRepository;
using DapperForApi.RequestResponse;
using DapperForApi.RequestResponse.Request;
using DapperForApi.Tablolar;
using System.Linq;
using System.Threading.Tasks;

namespace DapperForApi.LayerBusiness
{
    public class KategoriBusiness : IKategoriBusiness
    {
        private readonly IKategoriRepository _kategoriRepository;

        public KategoriBusiness(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }

        public async Task<KategoriResponse> GetAsync(long id)
        {
            var kategoriResponse = new KategoriResponse();
            var kategori = await _kategoriRepository.GetAsync(id);
            if (kategori == null)
            {
                kategoriResponse.Message = "Kategori Bulunamadı.";
                kategoriResponse.Kategoriler = null;
            }
            else
            {
                kategoriResponse.Kategoriler.Add(kategori);
            }
            return kategoriResponse;
        }

        public async Task<KategoriResponse> GetAllAsync()
        {
            var kategoriResponse = new KategoriResponse();
            var kategoriler = await _kategoriRepository.GetAllAsync();
            var kategorilerListesi = kategoriler.ToList();
            if (kategorilerListesi.ToList().Count == 0)
            {
                kategoriResponse.Message = "Kategori Bulunamadı.";
                kategoriResponse.Kategoriler = null;
            }
            else
            {
                kategoriResponse.Kategoriler.AddRange(kategorilerListesi);
            }
            return kategoriResponse;
        }

        public async Task<KategoriResponse> AddAsync(KategoriRequest kategoriRequest)
        {
            var kategori = new Kategori()
            {
                KategoriAdi = kategoriRequest.KategoriAdi,
                Aciklama = kategoriRequest.Aciklama
            };
            var sonuc = await _kategoriRepository.AddAsync(kategori);
            var kategoriResponse = new KategoriResponse();
            if (sonuc == 0)
            {
                kategoriResponse.Message = "Yeni Kayıt Eklenemedi.";
                kategoriResponse.Kategoriler = null;
            }
            else
            {
                kategoriResponse.Message = "Yeni Kayıt Ekleme işlemi başarılı.";
                kategoriResponse.Kategoriler = null;
            }
            return kategoriResponse;
        }

        public async Task<KategoriResponse> DeleteAsync(long id)
        {
            var kategoriResponse = new KategoriResponse();
            var sonuc = await _kategoriRepository.DeleteAsync(id);
            if (sonuc == 0)
            {
                kategoriResponse.Message = "Kategori Bulunamadı.";
                kategoriResponse.Kategoriler = null;
            }
            else
            {
                kategoriResponse.Message = "Kategori Silme işlemi başarılı.";
                kategoriResponse.Kategoriler = null;
            }
            return kategoriResponse;
        }
    }
}