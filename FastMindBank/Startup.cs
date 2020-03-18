using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using FastMindBank.Model.Contrato;
using FastMindBank.Repository;
using AutoMapper;
using FastMindBank.Model;
using FastMindBank.AppService;
using FastMindBank.Models;

namespace FastMindBank
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .AddJsonFile("appsettings.Development.json", true)
               .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAutoMapper();
            services.AddDbContext<FastMindBankContext>(options => options.UseSqlServer(Configuration["Data:FastMindBank:ConnectionString"], b => b.MigrationsAssembly("FastMindBank")));
            services.AddTransient<IFastMindBankRepository, FastMindBankRepository>();
            services.AddTransient<ServicoContaCorrente>();
            services.AddTransient<ApplicationFastMindBankService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            SeedData.SeedDatabase(services.GetRequiredService<FastMindBankContext>());
        }
    }
}
