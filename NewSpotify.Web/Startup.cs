﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewSpotify.Models.Models.HelperModels;
using NewSpotify.Web.Services;

namespace NewSpotify.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession( o =>
            {
                o.IdleTimeout = TimeSpan.FromSeconds(30);
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            } );

            services.Configure<AppSettings>(_configuration.GetSection("AppSettings"));
            services.AddTransient<MusicService>();
            services.AddTransient<ModelConverterService>();
            services.AddTransient<MemoryCache>();
            services.AddTransient<LikedSongsService>();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            app.UseDeveloperExceptionPage();
           
            app.UseMvcWithDefaultRoute();
        }
    }
}
