using Application.Core;
using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Interface;
using Domain.Main;
using Infrastructure.Data;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Transversal.Common;
using Transversal.Mapper;

namespace SIROS.Web
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
            // INSTANCIAR AUTOMAPPER
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //OPTIMIZACION GZIP
            services.AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>());

            // JSON SEREALIZADOR
            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });

            // JWT
            var jwtSettingsSection = Configuration.GetSection("JWT");
            services.Configure<JwtDto.Settings>(jwtSettingsSection);

            var jwtSettings = jwtSettingsSection.Get<JwtDto.Settings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            // SINGLETON
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            // INSTANCIAR OBJETOS
            services.AddScoped<IMunicipalidadApplication, MunicipalidadApplication>();
            services.AddScoped<IMunicipalidadDomain, MunicipalidadDomain>();
            services.AddScoped<IMunicipalidadRepository, MunicipalidadRepository>();

            services.AddScoped<ISSOApplication, SSOApplication>();
            services.AddScoped<IJwtApplication, JwtApplication>();

            services.AddScoped<ISunatApplication, SunatApplication>();
            services.AddScoped<ISunarpApplication, SunarpApplication>();
            services.AddScoped<IReniecApplication, ReniecApplication>();

            services.AddScoped<IGeneralApplication, GeneralApplication>();
            services.AddScoped<IGeneralDomain, GeneralDomain>();
            services.AddScoped<IGeneralRepository, GeneralRepository>();

            services.AddScoped<IAdminApplication, AdminApplication>();
            services.AddScoped<IAdminDomain, AdminDomain>();
            services.AddScoped<IAdminRepository, AdminRepository>();

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseResponseCompression();

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
