using System;

namespace DapperForApi.Tablolar
{
    public class Kategori
    {
        public long Id { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
    }
}