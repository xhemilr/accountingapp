using AccountingApp.Application.Extensions;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using AccountingApp.Server.Filters;
using Microsoft.Extensions.Localization;
using AccountingApp.Infrastructure.Extensions;
using AccountingApp.Server.Extensions;
using AccountingApp.Server.Managers.Preferences;
using AccountingApp.Server.Middlewares;
using System.Security.Cryptography;
using System.Text;
using System;

namespace AccountingApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddForwarding(_configuration);
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
            services.AddCurrentUserService();
            services.AddSerialization();
            services.AddDatabase(Decrypt(_configuration.GetConnectionString("DefaultConnection"), _configuration["EncryptionKey"]).Replace("\\\\", "\\"));
            services.AddServerStorage(); //TODO - should implement ServerStorageProvider to work correctly!
            services.AddScoped<ServerPreferenceManager>();
            services.AddServerLocalization();
            services.AddIdentity();
            services.AddJwtAuthentication(services.GetApplicationSettings(_configuration));
            services.AddSignalR();
            services.AddApplicationLayer();
            services.AddApplicationServices();
            services.AddRepositories();
            services.AddSharedInfrastructure(_configuration);
            services.RegisterSwagger();
            services.AddInfrastructureMappings();
            services.AddHangfire(x => x.UseSqlServerStorage(Decrypt(_configuration.GetConnectionString("DefaultConnection"), _configuration["EncryptionKey"]).Replace("\\\\", "\\")));
            services.AddHangfireServer();
            services.AddControllers().AddValidators();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("https://xhemilr.github.io", "185.199.108.153:443", "0.0.0.0:443")
                    .AllowCredentials()
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddRazorPages();
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            services.AddLazyCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStringLocalizer<Startup> localizer)
        {
            app.UseForwarding(_configuration);
            app.UseExceptionHandling(env);
            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UsePathBase("/accountingapp/");
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles("accountingapp/");
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
                RequestPath = new PathString("/Files")
            });
            app.UseRequestLocalizationByCulture();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHangfireDashboard("/jobs", new DashboardOptions
            {
                DashboardTitle = localizer["Accounting App Jobs"],
                Authorization = new[] { new HangfireAuthorizationFilter() }
            });
            app.UseEndpoints();
            app.ConfigureSwagger();
            app.Initialize(_configuration);
        }

        private static string Decrypt(string value, string key)
        {
            using (var tripleDESCryptoService = TripleDES.Create())
            {
                using (var hashMD5Provider = MD5.Create())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Convert.FromBase64String(value);
                    return Encoding.UTF8.GetString(tripleDESCryptoService.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
                }
            }
        }
    }
}