using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Roomager.DataAccess;
using Roomager.DataAccess.DataAccessObjects;
using Roomager.Services.PaymentsServices;

namespace Roomager.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options=>options.EnableEndpointRouting=false);
            services.AddMemoryCache();
            services.AddSession();

            services.AddTransient<IDataAccess, DapperDataAccess>();
            services.AddTransient<IPaymentsRecordDAO, PaymentsRecordDAO>();
            services.AddTransient<IPaymentsConfigDAO, PaymentsConfigDAO>();
            services.AddTransient<IPaymentsRecordService, PaymentsRecordService>();
            services.AddTransient<IPaymentsConfigService, PaymentsConfigService>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
