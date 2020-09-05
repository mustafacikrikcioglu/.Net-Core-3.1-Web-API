using System;

namespace DapperForApi.Tablolar
{
    public class Urun
    {
        public long Id { get; set; }
        public long KategoriId { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public double Fiyat { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
    }
}