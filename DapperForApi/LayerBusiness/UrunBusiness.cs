using DapperForApi.LayerBusiness.InterfaceBusiness;
using DapperForApi.LayerDal.InterfaceRepository;
using DapperForApi.RequestResponse;
using DapperForApi.RequestResponse.Request;
using DapperForApi.Tablolar;
using System.Linq;
using System.Threading.Tasks;

namespace DapperForApi.LayerBusiness
{
    public class UrunBusiness : IUrunBusiness
    {
        private readonly IUrunRepository _urunRepository;

        public UrunBusiness(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }

        public async Task<UrunResponse> GetAsync(long id)
        {
            var urunResponse = new UrunResponse();
            var urun = await _urunRepository.GetAsync(id);
            if (urun == null)
            {
                urunResponse.Message = "Ürün Bulunamadı.";
                urunResponse.Urunler = null;
            }
            else
            {
                urunResponse.Urunler.Add(urun);
            }
            return urunResponse;
        }

        public async Task<UrunResponse> GetAllAsync()
        {
            var urunResponse = new UrunResponse();
            var urunler = await _urunRepository.GetAllAsync();
            var urunlerListesi = urunler.ToList();
            if (urunlerListesi.ToList().Count == 0)
            {
                urunResponse.Message = "Ürün Bulunamadı.";
                urunResponse.Urunler = null;
            }
            else
            {
                urunResponse.Urunler.AddRange(urunlerListesi);
            }
            return urunResponse;
        }

        public async Task<UrunResponse> AddAsync(UrunRequest urunRequest)
        {
            var urun = new Urun()
            {
                KategoriId = urunRequest.KategoriId,
                UrunAdi = urunRequest.UrunAdi,
                Aciklama = urunRequest.Aciklama,
                Fiyat = urunRequest.Fiyat
            };
            var sonuc = await _urunRepository.AddAsync(urun);
            var urunResponse = new UrunResponse();
            if (sonuc == 0)
            {
                urunResponse.Message = "Yeni Kayıt Eklenemedi.";
                urunResponse.Urunler = null;
            }
            else
            {
                urunResponse.Message = "Yeni Kayıt Ekleme işlemi başarılı.";
                urunResponse.Urunler = null;
            }
            return urunResponse;
        }

        public async Task<UrunResponse> DeleteAsync(long id)
        {
            var urunResponse = new UrunResponse();
            var sonuc = await _urunRepository.DeleteAsync(id);
            if (sonuc == 0)
            {
                urunResponse.Message = "Ürün Bulunamadı.";
                urunResponse.Urunler = null;
            }
            else
            {
                urunResponse.Message = "Ürün Silme işlemi başarılı.";
                urunResponse.Urunler = null;
            }
            return urunResponse;
        }
    }
}