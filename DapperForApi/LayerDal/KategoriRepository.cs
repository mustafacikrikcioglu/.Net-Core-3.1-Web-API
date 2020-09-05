using Dapper;
using DapperForApi.LayerDal.InterfaceRepository;
using DapperForApi.Tablolar;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DapperForApi.LayerDal
{
    public class KategoriRepository : IKategoriRepository
    {
        private readonly string _connectionString;

        private IDbConnection MyConnection => new SqlConnection(_connectionString);

        public KategoriRepository()
        {
            _connectionString = AppBilgilerim.AppDbConnectionString;
        }

        public async Task<Kategori> GetAsync(long id)
        {
            using var dbConnection = MyConnection;
            const string query = @"SELECT [Id], [KategoriAdi], [Aciklama], [OlusturmaTarihi] FROM [dbo].[Kategori] WHERE [Id] = @Id";
            var kategori = await dbConnection.QueryFirstOrDefaultAsync<Kategori>(query, new { @Id = id });
            return kategori;
        }

        public async Task<IEnumerable<Kategori>> GetAllAsync()
        {
            using var dbConnection = MyConnection;
            const string query = @"SELECT [Id], [KategoriAdi], [Aciklama], [OlusturmaTarihi] FROM [dbo].[Kategori]";
            var kategoriler = await dbConnection.QueryAsync<Kategori>(query);
            return kategoriler;
        }

        public async Task<int> AddAsync(Kategori kategori)
        {
            using var dbConnection = MyConnection;
            const string query = @"INSERT INTO [dbo].[Kategori] ([KategoriAdi], [Aciklama], [OlusturmaTarihi]) VALUES (@KategoriAdi, @Aciklama, @OlusturmaTarihi)";
            return await dbConnection.ExecuteAsync(query, kategori);
        }

        public async Task<int> DeleteAsync(long id)
        {
            var gelenId = new { @Id = id };
            using var dbConnection = MyConnection;
            const string query = @"SELECT [Id], [KategoriAdi], [Aciklama], [OlusturmaTarihi] FROM [dbo].[Kategori] WHERE [Id] = @Id";
            var urun = await dbConnection.QueryFirstOrDefaultAsync<Urun>(query, gelenId);
            if (urun == null)
            {
                return 0;
            }
            else
            {
                const string query2 = @"DELETE FROM [dbo].[Kategori] WHERE [Id] = @Id";
                var sonuc = await dbConnection.ExecuteAsync(query2, gelenId);
                return sonuc;
            }
        }
    }
}