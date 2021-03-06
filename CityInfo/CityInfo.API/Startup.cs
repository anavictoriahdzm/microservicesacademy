﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Microsoft.OpenApi.Models;

namespace CityInfo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //quitar el (;) para poder usar el codigo de abajo
            services.AddMvc();

            //Para que el texto lo regrese en XML
            /*.AddMvcOptions(o =>
            {
                o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });*=

        //Para que el texto lo regrese en Json
           /* .AddJsonOptions(O =>
           {
               if (O.SerializerSettings.ContractResolver != null)
               {
                   var castedResolver = O.SerializerSettings.ContractResolver
                   as DefaultContractResolver;
                   castedResolver.NamingStrategy = null;
               }
           });*/

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "CityInfo API", Version = "v1"}));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else 
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CityInfo API"));
        }
    }
}
