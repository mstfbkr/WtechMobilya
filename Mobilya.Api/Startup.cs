using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mobilya.Api.Helpers;
using Mobilya.Business.Abstract;
using Mobilya.Business.Concrete;
using Mobilya.DataAccess;
using Mobilya.DataAccess.Abstract;
using Mobilya.DataAccess.Concrete;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MobilyaDBContext>(_dbContext => _dbContext.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddSwaggerDocument();
            services.AddRazorPages();

            services.AddControllersWithViews()
                  .AddNewtonsoftJson(options =>
                         options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();//requestler ayný olduðu sürece ayný sonuclar üretir 
            services.AddTransient<GenericHelperMothods>();




            //////services.AddTransient  gelen her bir request olayýnda sýnýfý yenileyip sonuc üretir
            //////services.AddSingleton 


            //nugettan 3.1.3 indirdik
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,            //Token deðerinin kimlerin hangi uygulamalarýn kullanýrlcaðýný belirler
                ValidateIssuer = true,              //Oluþturulan token deðerini kim daðýtmýþtýr
                ValidateLifetime = true,            //Oluþturulan token deðerinin  yaþam süresi
                ValidateIssuerSigningKey = true,    // üretilen token deðerinin uygulamamýxza ait olup olmadðýný ile alakalý security keyi
                ValidIssuer = Configuration["Token:Issuer"],//Appsettingde tanýmlaanan Issuer içindeki tanýmý ValidIssuer'e atadýk
                ValidAudience = Configuration["Token:Audience"],//Appsettingde tanýmlaanan Audience içindeki tanýmý ValidAudience'e atadýk
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),//Configuration nesnesi ile appsetting.json'a ulaþabildik,SecurityKey'i þifareleyerek simetriðini aldýk
                ClockSkew = TimeSpan.Zero       //Token süresinin uzatýlmasýný saðlar

            }); //appsettings'e token kodlarý ekledik 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            //app.UseAuthorization(); 
            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

        }
    }
}
