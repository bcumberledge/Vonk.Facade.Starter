﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Vonk.Core.Configuration;
using Vonk.Core.Operations.Search;
using Vonk.Core.Pluggability;
using Vonk.Fhir.R3;

namespace Vonk.Facade.Starter
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddFhirServices()
                .AddVonkMinimalServices()
                .AddSearchServices()
                .AddViSiServices()
                .AllowResourceTypes("Patient")
            ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseVonkMinimal()
                .UseSearch()
            ;
        }
    }
}
