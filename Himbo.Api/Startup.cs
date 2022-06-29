using Himbo.Api.Core.Common;
using Himbo.Api.Extensions;
using Himbo.Api.FileUpload;
using Himbo.Application.Emails;
using Himbo.Application.Logging;
using Himbo.Application.UseCases;
using Himbo.DataAccess;
using Himbo.Implementation;
using Himbo.Implementation.Emails;
using Himbo.Implementation.Logging;
using Himbo.Implementation.UseCases.UseCaseLogger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Himbo.Api
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

            #region Define and Register AppSettings
            var settings = new AppSettings();
            Configuration.Bind(settings); // Dinamically checks appsettings.Development.json and tries to bind Json "keys" to AppSettings "properties" 
            // eg. public string ConnString { get; set; }
            // eg. "ConnString": "Data Source=DESKTOP-BIQA9C7;Initial Catalog=HimboDb;Integrated Security=True",
            services.AddSingleton(settings); // Need only one instance
            #endregion

            #region Register Services from Extension Container
            services.AddApplicationUser();
            services.AddJwt(settings);
            //services.AddHimboDbContext(); - Legacy
            //services.AddUseCases(); - Legacy
            #endregion

            #region Register Services from other Projects (Shorter way)
            services.ConfigureImplementationServices();
            services.ConfigureDataAccessServices(settings.ConnString);
            #endregion

            #region Register Loggers (Exception/UseCase)
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>(); // When someone asks for IExceptionLogger we will return Implementation - ConsoleExceptionLogger
            //services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
            services.AddTransient<IUseCaseLogger>(x => new SpUseCaseLogger(settings.ConnString));

            #endregion

            #region Email Senders
            var emailOptions = settings.EmailOptions;
            services.AddTransient<IEmailSender>(x =>
                new SmtpEmailSender
                (
                    emailOptions.FromEmail,
                    emailOptions.Password,
                    emailOptions.Port,
                    emailOptions.Host
                )
            );
            #endregion

            #region File Uploader
            services.AddSingleton<IFileUploader, FileUploader>();
            #endregion

            #region Register UseCaseHandler
            services.AddTransient<UseCaseHandler>();
            #endregion

            #region Register HttpContext 
            // Encapsulates all HTTP-specific information about an individual HTTP request.
            services.AddHttpContextAccessor();
            #endregion

            /*
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            */
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Himbo.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Himbo.Api v1"));
            }

            //app.UseHttpsRedirection();

            #region Routing
            app.UseRouting();
            #endregion

            #region Middleware
            app.UseMiddleware<GlobalExceptionHandler>();
            #endregion

            #region Auth
            // Order matters
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion

            #region Static Files
            app.UseStaticFiles();
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
