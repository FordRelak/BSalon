using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSalonWebApp.Data;
using BSalonWebApp.Models.Schedule;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BSalonWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();

            services.AddDbContext<BSalonDbContext>(o =>
                o.UseSqlServer(@"Data Source=88.135.50.215; Initial Catalog=BSalon;
                                 User ID=Misha; Password=789xxx44XX; Connect Timeout=30;
                                 Encrypt=False; TrustServerCertificate=False;
                                 ApplicationIntent=ReadWrite; MultiSubnetFailover=False"));
            services.AddHostedService<RecordsTableUpdater>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();  // Добавляем маршрутизацию для RazorPages
            });
        }
    }
}
