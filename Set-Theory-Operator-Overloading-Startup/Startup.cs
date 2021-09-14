using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Set_Theory_Operator_Overloading_LIB.Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_Startup
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
            services.AddScoped<Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int>,Set_Theory_Operator_Overloading_LIB.Sets.Set<int>>();
            services.AddScoped<Set_Theory_Operator_Overloading_LIB.Interfaces.IList<int>, Set_Theory_Operator_Overloading_LIB.Sets.List<int>>();
            services.AddScoped<Set_Theory_Operator_Overloading_LIB.Interfaces.ISet<int>, Set_Theory_Operator_Overloading_LIB.Sets.Set<int>>();
            services.AddScoped<Set_Theory_Operator_Overloading_LIB.Interfaces.IGraph<int>, Set_Theory_Operator_Overloading_LIB.Sets.Graph<int>>();
            services.AddScoped<Set_Theory_Operator_Overloading_LIB.Interfaces.IBinaryTree<int>, Set_Theory_Operator_Overloading_LIB.Sets.BinaryTree<int>>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Set_Theory_Operator_Overloading_Startup", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Set_Theory_Operator_Overloading_Startup v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
