using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGetWay
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
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme).AddIdentityServerAuthentication("ocelotKey", options =>
             {
                 options.Authority = "http://dev.oauth.fanyouvip.com";
                 options.RequireHttpsMetadata = false;
                 options.ApiName = "apigetway";
                 options.SupportedTokens = SupportedTokens.Both;
                 options.ApiSecret = "secret";
             });

            //var authenticationProviderKey = "ocelotKey";
            //Action<IdentityServerAuthenticationOptions> options = o =>
            //{
            //    o.Authority = "http://dev.oauth.fanyouvip.com";
            //    o.ApiName = "apigetway";
            //    o.SupportedTokens = SupportedTokens.Both;
            //    o.ApiSecret = "secret";
            //};

            //services.AddAuthentication()
            //    .AddIdentityServerAuthentication(authenticationProviderKey, options);

            services.AddOcelot(new ConfigurationBuilder().AddJsonFile("ocelot.json").Build());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseAuthentication().UseOcelot().Wait();
            app.UseMvc();
        }
    }
}
