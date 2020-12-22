using AutoMapper;
using DealSe.Common;
using DealSe.Data.Models;
using DealSe.Service.Interface;
using DealSe.Service.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using DealSe.Service;

namespace DealSe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //public class UniqueCode
        //{
        //    public readonly string UniqueCodeValue = "1C3564916BB4F55653FAC734DF36A";
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DealSeContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DealSeContext")));
            services.Configure<CustomSettings>(Configuration.GetSection("CustomSettings"));
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Admin/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml"); 
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
           // ConfigureCors(services);
            
            ConfigureSwagger(services);
            ConfigureJWTBearer(services);
            
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
                x.MultipartHeadersLengthLimit = int.MaxValue;
                x.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = ApiVersion.Default;
                options.ReportApiVersions = true;
            });

            services.AddDistributedMemoryCache();
            services.AddOptions();
            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromHours(8); options.Cookie.HttpOnly = true; });
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<UserService>();
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();


                    //If we want to display error message as per the status code otherwise remove status code
                    var statusCode = context.Response.StatusCode;
                    if (exceptionHandlerPathFeature.Path.Contains("/Admin/"))
                    {
                        context.Response.Redirect("/Admin/Error/Index/" + statusCode);
                    }
                    else
                    {
                        context.Response.Redirect("/Error/Index/" + statusCode);
                    }
                });
            });
            app.UseRouting();
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            
            CustomSwagger(app);
            
            app.UseCors("AllowOrigin");
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMvc(BuildRoutes());          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                name: "AdminArea",
                areaName: "Admin",
                pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        //private static void ConfigureCors(IServiceCollection services)
        //{
        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy("AllowOrigin",
        //        builder => builder
        //                    .AllowAnyMethod()
        //                    .AllowAnyHeader()
        //                    .AllowAnyOrigin()
        //        );
        //    });
        //}
        
        private void ConfigureSwagger(IServiceCollection services)
        {
            //Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "DealSe API"
                });

                // Add security definitions
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference()
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, Array.Empty<string>() }
                });

                c.DocInclusionPredicate((docName, description) => true);
            });
        }
        
        private void CustomSwagger(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),

            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DealSe V1");
                c.RoutePrefix = "help-docs";
            });
        }

        private void ConfigureJWTBearer(IServiceCollection services)
        {
            // configure strongly typed settings objects
            var customSettingsSection = Configuration.GetSection("CustomSettings");
            services.Configure<CustomSettings>(customSettingsSection);

            // configure jwt authentication
            var customSettings = customSettingsSection.Get<CustomSettings>();
            var key = Encoding.ASCII.GetBytes(customSettings.JWTSecret);
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
                    ValidateAudience = false
                };
            });
        }
		private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ISiteSettingService, SiteSettingService>();
            services.AddScoped<IEmailTemplateService, EmailTemplateService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IStoreTypeService, StoreTypeService>();
        }
    }
}