using DapperForApi.LayerBusiness;
using DapperForApi.LayerBusiness.InterfaceBusiness;
using DapperForApi.LayerDal;
using DapperForApi.LayerDal.InterfaceRepository;
using DapperForApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO.Compression;

namespace DapperForApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // Bu y�ntem �al��ma zaman� taraf�ndan �a�r�l�r.Kapsay�c�ya hizmet eklemek i�in bu y�ntemi kullan�n.
        public void ConfigureServices(IServiceCollection services)
        {
            // Responselar�m�n s�k��t�r�lmas�n� sa�lamak i�in.
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });
            // Response S�k��t�rma konfig�rasyonunu ayarlamak i�in.
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);

            services.AddControllers();

            // Uygulamam�n servislerini repositorylerini kaydetmek ve ba��ml�l�ktan kurtarmak i�in.
            services.AddTransient<IKategoriBusiness, KategoriBusiness>();
            services.AddTransient<IKategoriRepository, KategoriRepository>();

            services.AddTransient<IUrunBusiness, UrunBusiness>();
            services.AddTransient<IUrunRepository, UrunRepository>();

            // Swagger olu�turucuyu kaydetmem i�in.
            services.AddSwaggerGen();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "Dapper APIm",
            //        Description = "ASP.NET Core Web APIm",
            //        TermsOfService = new Uri("https://example.com/terms"),
            //        Contact = new OpenApiContact
            //        {
            //            Name = "Benim Ad�m",
            //            Email = "test@test.com",
            //            Url = new Uri("https://example.com/twitter"),
            //        },
            //        License = new OpenApiLicense
            //        {
            //            Name = "Use under MIT",
            //            Url = new Uri("https://example.com/license"),
            //        }
            //    });

            //});
        }

        // Bu y�ntem �al��ma zaman� taraf�ndan �a�r�l�r. HTTP istek ard���k d�zenini yap�land�rmak i�in bu y�ntemi kullan�n.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Log dosyas�n� olu�turmak i�in.
            loggerFactory.AddFile("C:/@LogsDapperApi/DapperForApi-{Date}.txt");

            // Log olu�turmam i�in.
            app.UseMiddleware(typeof(GlobalException));//

            // Olu�turulan Swagger'� sunmak i�in etkinle�tirme.
            app.UseSwagger();

            // Swagger JSON u� noktas�n� belirterek Swagger-UI (HTML, JS, CSS vb.) olarak sunmak i�in etkinle�tirme.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Benim ASP.NET Core Web APIm");
                c.DocumentTitle = AppBilgilerim.AppDeveloper;
            });

            // Responselar�m�n s�k��t�r�lmas�n� sa�lamak i�in.
            app.UseResponseCompression();

            app.UseHttpsRedirection();

            // Static dosyalar�m�n cache tutulmas� i�in.
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = contet =>
                {
                    contet.Context.Response.Headers.Append("Cache-Control", $"public, max-age={604800}");
                }
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}