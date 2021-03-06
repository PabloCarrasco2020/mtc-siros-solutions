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
using Transversal.Common.Helper;
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
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
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

            this.LoadAppSettings(services);
            this.LoadSingletons(services);
            this.LoadScopes(services);
            this.LoadJWT(services);

            services.AddControllersWithViews();
            services.AddResponseCaching();
            services.AddSession();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/siros";
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

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

        #region CONFIGURACIONES

        private void LoadAppSettings(IServiceCollection services)
        {
            var oConnectionStrings = Configuration.GetSection("ConnectionStrings");
            services.Configure<AppSettings.ConnectionStrings>(oConnectionStrings);

            var oServicios = Configuration.GetSection("Servicios");
            services.Configure<AppSettings.Servicios>(oServicios);

            var oCredencialesSSO = Configuration.GetSection("CredencialesSSO");
            services.Configure<AppSettings.CredencialesSSO>(oCredencialesSSO);

            var oCredencialesMiddleWare = Configuration.GetSection("CredencialesMiddleWare");
            services.Configure<AppSettings.CredencialesMiddleWare>(oCredencialesMiddleWare);

            var oJWT = Configuration.GetSection("JWT");
            services.Configure<AppSettings.JWT>(oJWT);

            var oEmail = Configuration.GetSection("Email");
            services.Configure<AppSettings.Email>(oEmail);

            var oLogs = Configuration.GetSection("Logs");
            services.Configure<AppSettings.Logs>(oLogs);
        }

        private void LoadSingletons(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(this.Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton<IJwtApplication, JwtApplication>();
            services.AddSingleton<ISSOApplication, SSOApplication>();
            services.AddSingleton<ICaptchaApplication, CaptchaApplication>();
            services.AddSingleton<IEmailApplication, EmailApplication>();
            services.AddSingleton<ILogApplication, LogApplication>();
            services.AddSingleton<ISunatApplication, SunatApplication>();
            services.AddSingleton<ISunarpApplication, SunarpApplication>();
            services.AddSingleton<IReniecApplication, ReniecApplication>();
            services.AddSingleton<IOngeiApplication, OngeiApplication>();
        }

        private void LoadScopes(IServiceCollection services)
        {
            services.AddScoped<IMunicipalidadApplication, MunicipalidadApplication>();
            services.AddScoped<IMunicipalidadDomain, MunicipalidadDomain>();
            services.AddScoped<IMunicipalidadRepository, MunicipalidadRepository>();

            services.AddScoped<IEstacionServicioApplication, EstacionServicioApplication>();
            services.AddScoped<IEstacionServicioDomain, EstacionServicioDomain>();
            services.AddScoped<IEstacionServicioRepository, EstacionServicioRepository>();

            services.AddScoped<IContratoEsApplication, ContratoEsApplication>();
            services.AddScoped<IContratoEsDomain, ContratoEsDomain>();
            services.AddScoped<IContratoEsRepository, ContratoEsRepository>();

            services.AddScoped<ICombustibleApplication, CombustibleApplication>();
            services.AddScoped<ICombustibleDomain, CombustibleDomain>();
            services.AddScoped<ICombustibleRepository, CombustibleRepository>();

            services.AddScoped<ISucursalESApplication, SucursalESApplication>();
            services.AddScoped<ISucursalESDomain, SucursalESDomain>();
            services.AddScoped<ISucursalESRepository, SucursalESRepository>();
            
            services.AddScoped<IOperadorESApplication, OperadorESApplication>();
            services.AddScoped<IOperadorESDomain, OperadorESDomain>();
            services.AddScoped<IOperadorESRepository, OperadorESRepository>();

            services.AddScoped<IRutaApplication, RutaApplication>();
            services.AddScoped<IRutaDomain, RutaDomain>();
            services.AddScoped<IRutaRepository, RutaRepository>();

            services.AddScoped<ICoordenadaRutaApplication, CoordenadaRutaApplication>();
            services.AddScoped<ICoordenadaRutaDomain, CoordenadaRutaDomain>();
            services.AddScoped<ICoordenadaRutaRepository, CoordenadaRutaRepository>();

            services.AddScoped<IEmpresaApplication, EmpresaApplication>();
            services.AddScoped<IEmpresaDomain, EmpresaDomain>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            services.AddScoped<IOperadorEmpresaApplication, OperadorEmpresaApplication>();
            services.AddScoped<IOperadorEmpresaDomain, OperadorEmpresaDomain>();
            services.AddScoped<IOperadorEmpresaRepository, OperadorEmpresaRepository>();

            services.AddScoped<IRutaEmpresaApplication, RutaEmpresaApplication>();
            services.AddScoped<IRutaEmpresaDomain, RutaEmpresaDomain>();
            services.AddScoped<IRutaEmpresaRepository, RutaEmpresaRepository>();

            services.AddScoped<IVehiculoRutaEmpresaApplication, VehiculoRutaEmpresaApplication>();
            services.AddScoped<IVehiculoRutaEmpresaDomain, VehiculoRutaEmpresaDomain>();
            services.AddScoped<IVehiculoRutaEmpresaRepository, VehiculoRutaEmpresaRepository>();

            services.AddScoped<IFormularioOGTUApplication, FormularioOGTUApplication>();
            services.AddScoped<IFormularioOGTUDomain, FormularioOGTUDomain>();
            services.AddScoped<IFormularioOGTURepository, FormularioOGTURepository>();

            services.AddScoped<IGeneralApplication, GeneralApplication>();
            services.AddScoped<IGeneralDomain, GeneralDomain>();
            services.AddScoped<IGeneralRepository, GeneralRepository>();

            services.AddScoped<IAdminApplication, AdminApplication>();
            services.AddScoped<IAdminDomain, AdminDomain>();
            services.AddScoped<IAdminRepository, AdminRepository>();
        }

        private void LoadJWT(IServiceCollection services)
        {
            var oJWT = Configuration.GetSection("JWT");
            var oJwtSettings = oJWT.Get<AppSettings.JWT>();
            var oSecretKey = Encoding.ASCII.GetBytes(oJwtSettings.SecretKey);
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
                    IssuerSigningKey = new SymmetricSecurityKey(oSecretKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        #endregion
    }
}
