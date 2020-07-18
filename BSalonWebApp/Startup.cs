using BSalonWebApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BSalonWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRazorPages()
                .AddRazorRuntimeCompilation()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizePage("/AdministratorBoard");
                });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.AddDbContext<BSalonDbContext>(o =>
                o.UseSqlServer(@"Data Source=88.135.50.215; Initial Catalog=BSalon;
                                 User ID=Misha; Password=789xxx44XX; Connect Timeout=30;
                                 Encrypt=False; TrustServerCertificate=False;
                                 ApplicationIntent=ReadWrite; MultiSubnetFailover=False"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();  // Добавляем маршрутизацию для RazorPages
            });
        }
    }
}
