using BusinessLogicLayer.Functionality;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Сrypto_Monitor.Mapper;
using Сrypto_Monitor.Mapper.BusinesDataToModel;
using Сrypto_Monitor.Mapper.ViewModelToBusinesModel;

namespace Krypto_Monitor
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
            services.AddAutoMapper(typeof(CryptaBLDataCrypta), typeof(CryptaDataCrypta), typeof(ExpectedCostBLDataExpectedCost), typeof(ExpectedCostDataExpectedCost), typeof(OrderDataOrder));
            services.AddAutoMapper(typeof(CryptaBLCrypta), typeof(ExpectedCostBLExpectedCost), typeof(OrderBLOrder), typeof(CryptaPLToCryptaBL), typeof(UserRegistredBLDataUser));
            services.AddAutoMapper(typeof(UserRegistredUserRegistredBL), typeof(CryptaOrderOrderBL));
            services.AddScoped<CryptaRepo>();
            services.AddScoped<ExpectedCostRepo>();
            services.AddScoped<OrderRepo>();
            services.AddScoped<UserRepo>();
            services.AddScoped<CryptaServices>();
            services.AddScoped<ExpectedCostApi>();
            services.AddScoped<OrderCryptaServices>();
            services.AddScoped<UserRegistredServices>();
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Login/Login");
                });
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CryptaContext>(options =>
                options.UseSqlServer(connection));
            services.AddControllersWithViews();
            
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Main}/{action=StartPage}/{id?}");
            });
        }
    }
}
