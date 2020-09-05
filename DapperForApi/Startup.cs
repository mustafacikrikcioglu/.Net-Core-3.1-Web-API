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

        // Bu yöntem çalýþma zamaný tarafýndan çaðrýlýr.Kapsayýcýya hizmet eklemek için bu yöntemi kullanýn.
        public void ConfigureServices(IServiceCollection services)
        {
            // Responselarýmýn sýkýþtýrýlmasýný saðlamak için.
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });
            // Response Sýkýþtýrma konfigürasyonunu ayarlamak için.
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);

            services.AddControllers();

            // Uygulamamýn servislerini repositorylerini kaydetmek ve baðýmlýlýktan kurtarmak için.
            services.AddTransient<IKategoriBusiness, KategoriBusiness>();
            services.AddTransient<IKategoriRepository, KategoriRepository>();

            services.AddTransient<IUrunBusiness, UrunBusiness>();
            services.AddTransient<IUrunRepository, UrunRepository>();

            // Swagger oluþturucuyu kaydetmem için.
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
            //            Name = "Benim Adým",
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

        // Bu yöntem çalýþma zamaný tarafýndan çaðrýlýr. HTTP istek ardýþýk düzenini yapýlandýrmak için bu yöntemi kullanýn.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Log dosyasýný oluþturmak için.
            loggerFactory.AddFile("C:/@LogsDapperApi/DapperForApi-{Date}.txt");

            // Log oluþturmam için.
            app.UseMiddleware(typeof(GlobalException));//

            // Oluþturulan Swagger'ý sunmak için etkinleþtirme.
            app.UseSwagger();

            // Swagger JSON uç noktasýný belirterek Swagger-UI (HTML, JS, CSS vb.) olarak sunmak için etkinleþtirme.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Benim ASP.NET Core Web APIm");
                c.DocumentTitle = AppBilgilerim.AppDeveloper;
            });

            // Responselarýmýn sýkýþtýrýlmasýný saðlamak için.
            app.UseResponseCompression();

            app.UseHttpsRedirection();

            // Static dosyalarýmýn cache tutulmasý için.
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