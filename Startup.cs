using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using DevExpress.XtraReports.Web.Extensions;
using report.Services;

using DevExpress.XtraReports.Web.ClientControls;

namespace report
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDevExpressControls();
            services.AddScoped<ReportStorageWebExtension, CustomReportStorageWebExtension>();
            services.AddControllersWithViews();
            services.AddCors(options => {
                options.AddPolicy("AllowCorsPolicy", builder => {
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                    builder.WithHeaders("Content-Type");
                });
            });
        }


        void ProcessException(Exception ex, string message) {
            // Log exceptions here. For instance:
            System.Diagnostics.Debug.WriteLine("[{0}]: Exception occured. Message: '{1}'. Exception Details:\r\n{2}", 
                DateTime.Now, message, ex);
            Console.WriteLine("[{0}]: Exception occured. Message: '{1}'. Exception Details:\r\n{2}", 
                DateTime.Now, message, ex);
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("AllowCorsPolicy");
            app.UseDevExpressControls();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            DevExpress.XtraReports.Web.ClientControls.LoggerService.Initialize(ProcessException);
        }
    }
}
