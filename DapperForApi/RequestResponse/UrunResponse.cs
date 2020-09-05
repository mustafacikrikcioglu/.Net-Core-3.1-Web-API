using DapperForApi.Tablolar;
using System.Collections.Generic;

namespace DapperForApi.RequestResponse
{
    public class UrunResponse
    {
        public UrunResponse()
        {
            Urunler = new List<Urun>();
        }

        public string Message { get; set; }

        public List<Urun> Urunler { get; set; }
    }
}