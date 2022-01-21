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
            //services.AddCors(options =>
            //                 options.AddDefaultPolicy(builder =>
            //                 builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));


            //////services.AddTransient  gelen her bir request olay�nda s�n�f� yenileyip sonuc �retir
            //////services.AddSingleton 
            //nugettan 3.1.3 indirdik
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,            //Token de�erinin kimlerin hangi uygulamalar�n kullan�rlca��n� belirler
                ValidateIssuer = true,              //Olu�turulan token de�erini kim da��tm��t�r
                ValidateLifetime = true,            //Olu�turulan token de�erinin  ya�am s�resi
                ValidateIssuerSigningKey = true,    // �retilen token de�erinin uygulamam�xza ait olup olmad��n� ile alakal� security keyi
                ValidIssuer = Configuration["Token:Issuer"],//Appsettingde tan�mlaanan Issuer i�indeki tan�m� ValidIssuer'e atad�k
                ValidAudience = Configuration["Token:Audience"],//Appsettingde tan�mlaanan Audience i�indeki tan�m� ValidAudience'e atad�k
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),//Configuration nesnesi ile appsetting.json'a ula�abildik,SecurityKey'i �ifareleyerek simetri�ini ald�k
                ClockSkew = TimeSpan.Zero       //Token s�resinin uzat�lmas�n� sa�lar

            }); //appsettings'e token kodlar� ekledik 

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UsersService>();
            services.AddTransient<IProductService, ProductService>();//requestler ayn� oldu�u s�rece ayn� sonuclar �retir 
            services.AddTransient<GenericHelperMothods>();
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
            app.UseRouting();
            //app.UseCors(x => x
            //    .AllowAnyOrigin()
            //   .AllowAnyMethod()
            //   .AllowAnyHeader()); //Apilara d��ar�dan eri�im sa�lar
            app.UseAuthentication();
            //app.UseAuthorization();
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
