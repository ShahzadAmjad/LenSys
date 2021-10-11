using LenSys.Models;
using LenSys.Models.AppAssetFinance;
using LenSys.Models.AppAssetFinance.AppAssetFinanceBusniess;
using LenSys.Models.AppAssetFinance.AppAssetFinanceIndividual;
using LenSys.Models.AppBusniessFinance;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceBusniess;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceIndividual;
using LenSys.Models.AppDevelopmentFinance;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceBusniess;
using LenSys.Models.AppDevelopmentFinance.AppDevelopmentFinanceIndividual;
using LenSys.Models.AppPropertyFinance;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceBusniess;
using LenSys.Models.AppPropertyFinance.AppPropertyFinanceIndividual;
using LenSys.Models.BusniessKeyPrincipals;
using LenSys.Models.BusniessLiabilities;
using LenSys.Models.BusniessServiceability;
using LenSys.Models.BusniessUploadDocument;
using LenSys.Models.Home;
using LenSys.Models.Home.AllApplications;
using LenSys.Models.IndividualPropertySchedule;
using LenSys.Models.IndividualUploadDocuments;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("LenSysDBConnection"), sqlServerOptions => sqlServerOptions.CommandTimeout(60)));

            services.AddMvc(options => options.EnableEndpointRouting = false);



            services.AddSingleton<ILeadRepository, MockLeadRepository>();
            services.AddSingleton<IPropertyScheduleRepository, MockPropertyScheduleRepository>();
            services.AddSingleton<IKeyPrincipalsRepository, MockKeyPrincipalsRepository>();
            services.AddSingleton<IBusniessLiabilitiesRepository, MockBusniessLiabilitiesRepository>();
            services.AddSingleton<IServiceabilityRepository, MockServicebilityRepository>();
            services.AddSingleton<IBusniessDocumentsRepository, MockBusniessDocumentsRepository>();
            services.AddSingleton<IindividualDocumentsRepository, MockIndividualDocumentsRepository>();

            services.AddScoped<IAppAssetFinanceRepository, SQLAppAssetFinanceReository>();
            services.AddScoped<IAppBusniessFinanceRepository, SQLAppBusniessFinanceRepository>();
            services.AddScoped<IAppDevelopmentFinanceRepository, SQLAppDevelopmentFinanceRepository>();
            services.AddScoped<IAppPropertyFinanceRepository, SQLAppPropertyFinanceRepository>();

            services.AddScoped<IAllApplicationsRepository, SQLAllApplicationsRepository>();

            services.AddSingleton<IAppBusniessFinanceSecurityDetailsRepository, MockAppBusniessFinanceSecurityDetailsRepository>();
            services.AddSingleton<IAppDevelopmentFinanceSecurityDetailsRepository, MockAppDevelopmentFinanceSecurityDetailsRepository>();
            services.AddSingleton<IAppPropertyFinanceSecurityDetailsRepository, MockAppPropertyFinanceSecurityDetailsRepository>();
                        
            services.AddSingleton<IAppAssetFinanceBusniessRepository, MockAppAssetFinanceBusniessRepository>();
            services.AddSingleton<IAppAssetFinanceIndividualRepository, MockAppAssetFinanceIndividualRepository>();

            services.AddSingleton<IAppBusniessFinanceBusniessRepository, MockAppBusniessFinanceBusniessRepository>();
            services.AddSingleton<IAppBusniessFinanceIndividualRepository, MockAppBusniessFinanceIndividualRepository>();

            services.AddSingleton<IAppDevelopmentFinanceBusniessRepository, MockAppDevelopmentFinanceBusniessRepository>();
            services.AddSingleton<IAppDevelopmentFinanceIndividualRepository, MockAppDevelopmentFinanceIndividualRepository>();

            services.AddSingleton<IAppPropertyFinanceBusniessRepository, MockAppPropertyFinanceBusniessRepository>();
            services.AddSingleton<IAppPropertyFinanceIndividualRepository, MockAppPropertyFinanceIndividualRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();


            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
