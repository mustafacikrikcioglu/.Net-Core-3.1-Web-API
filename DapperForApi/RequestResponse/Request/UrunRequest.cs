namespace DapperForApi.RequestResponse.Request
{
    public class UrunRequest
    {
        public long KategoriId { get; set; }

        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public double Fiyat { get; set; }
    }
}