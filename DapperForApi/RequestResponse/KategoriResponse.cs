using DapperForApi.Tablolar;
using System.Collections.Generic;

namespace DapperForApi.RequestResponse
{
    public class KategoriResponse
    {
        public KategoriResponse()
        {
            Kategoriler = new List<Kategori>();
        }

        public string Message { get; set; }

        public List<Kategori> Kategoriler { get; set; }
    }
}