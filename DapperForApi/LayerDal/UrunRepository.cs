using Dapper;
using DapperForApi.LayerDal.InterfaceRepository;
using DapperForApi.Tablolar;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DapperForApi.LayerDal
{
    public class UrunRepository : IUrunRepository
    {
        private readonly string _connectionString;

        private IDbConnection MyConnection => new SqlConnection(_connectionString);

        public UrunRepository()
        {
            _connectionString = AppBilgilerim.AppDbConnectionString;
        }

        public async Task<Urun> GetAsync(long id)
        {
            using var dbConnection = MyConnection;
            const string query = @"SELECT [Id] , [KategoriId], [UrunAdi], [Aciklama], [Fiyat], [OlusturmaTarihi] FROM [dbo].[Urun] WHERE [Id] = @Id";
            var urun = await dbConnection.QueryFirstOrDefaultAsync<Urun>(query, new { @Id = id });
            return urun;
        }

        public async Task<IEnumerable<Urun>> GetAllAsync()
        {
            using var dbConnection = MyConnection;
            const string query = @"SELECT [Id], [KategoriId], [UrunAdi], [Aciklama], [Fiyat], [OlusturmaTarihi] FROM [dbo].[Urun]";
            var urunler = await dbConnection.QueryAsync<Urun>(query);
            return urunler;
        }

        public async Task<int> AddAsync(Urun urun)
        {
            using var dbConnection = MyConnection;
            const string query = @"INSERT INTO [dbo].[Urun] ([KategoriId], [UrunAdi], [Aciklama], [Fiyat], [OlusturmaTarihi]) VALUES (@KategoriId, @UrunAdi, @Aciklama, @Fiyat, @OlusturmaTarihi)";
            return await dbConnection.ExecuteAsync(query, urun);
        }

        public async Task<int> DeleteAsync(long id)
        {
            var gelenId = new { @Id = id };
            using var dbConnection = MyConnection;
            const string query = @"SELECT [Id], [KategoriId], [UrunAdi], [Aciklama], [Fiyat], [OlusturmaTarihi] FROM [dbo].[Urun] WHERE [Id] = @Id";
            var urun = await dbConnection.QueryFirstOrDefaultAsync<Urun>(query, gelenId);
            if (urun == null)
            {
                return 0;
            }
            else
            {
                const string query2 = @"DELETE 
                                FROM [dbo].[Urun]
                                WHERE [Id] = @Id";
                var sonuc = await dbConnection.ExecuteAsync(query2, gelenId);
                return sonuc;
            }
        }
    }
}