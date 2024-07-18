using DataLayer;
using DataLayer.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace TarkhinehAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TarkhinehAPI", Version = "v1" });
            });
            services.AddDbContext<TarkhinehDbContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("TarkhinehDB")); });

            services.AddTransient<ITblAddressRepository, TblAddressRepository>();
            services.AddTransient<ITblBranchRepository, TblBranchRepository>();
            services.AddTransient<ITblCartRepository, TblCartRepository>();
            services.AddTransient<ITblCustomerRepository, TblCustomerRepository>();
            services.AddTransient<ITblDeliveryRepository, TblDeliveryRepository>();
            services.AddTransient<ITblFoodRepository, TblFoodRepository>();
            services.AddTransient<ITblOrderRepository, TblOrderRepository>();
            services.AddTransient<ITblPaymentRepository, TblPaymentRepository>();

            // add memory caching
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TarkhinehAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
