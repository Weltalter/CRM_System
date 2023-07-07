using CRM_System.Data;
using CRM_System.Data.Interfaces;
using CRM_System.Data.Mocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRM_System.Data.Repository;

namespace CRM_System {
    public class Startup {
        private IConfigurationRoot _confString;

        public Startup(IHostingEnvironment hostEnv) {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<DBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IClients, ClientRepository>();
            services.AddTransient<IOrders, OrderRepository>();
            services.AddMvc();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseStaticFiles();

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();

            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }


    }
}
