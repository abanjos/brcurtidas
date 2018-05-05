using AutoMapper;
using BRCurtidas.Data;
using BRCurtidas.PagSeguro;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BRCurtidas.Web.Api
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
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BRCurtidasDatabase")));

            services.AddTransient<IPagSeguroClient>(_ =>
            {
                var url = Configuration["PagSeguro:Url"];
                var email = Configuration["PagSeguro:Email"];
                var token = Configuration["PagSeguro:Token"];
                var credentials = new PagSeguroCredentials(email, token);

                return new PagSeguroClient(url, credentials);
            });

            services.AddAutoMapper();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
