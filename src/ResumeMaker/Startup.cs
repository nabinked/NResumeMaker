using System;
using DbPortal;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc.Routing;
using Microsoft.AspNet.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.WebEncoders;
using ResumeMaker.Common;
using ResumeMaker.Services;
using ResumeMaker.Services.Account;
using ResumeMaker.Services.Connection;
using ResumeMaker.Services.ToastNotification;
using ResumeMaker.ViewModels;

namespace ResumeMaker
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.

            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            Configuration = builder.Build();
            ConnectionString = Configuration.GetSection("AppSettings:ConnectionString").Value;
            DbPortal.DbConnection.SetConnectionString(ConnectionString);
        }

        public IConfigurationRoot Configuration { get; set; }

        private string ConnectionString { get; set; }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<ISignInManager, SignInManager>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IResumeBuilderViewHelper, ResumeBuilderViewHelper>();
            services.AddScoped<User, User>();
            services.Configure<Appsettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton<IConnectionFactory, SqlConnectionFactory>();
            services.AddInstance<IToastNotification>(new ToastNotification()
            {
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Add the following to the request pipeline only in development environment.
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }


            // Add the platform handler to the request pipeline.
            
            app.UseStaticFiles(
                new StaticFileOptions
                {
                    ServeUnknownFileTypes = true,
                    DefaultContentType = "image/png"
                });

            app.UseIISPlatformHandler();

            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();

            app.UseCookieAuthentication(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AuthenticationScheme = "Cookies";
                options.CookieName = ".AptNet.ExternalCookie";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.AutomaticAuthenticate = true;
                options.AccessDeniedPath = "/Account/Login";
            });

            app.UseFacebookAuthentication(options =>
            {
                options.AppId = "1035003543197580";
                options.AppSecret = "237e18f1289ac356b8b5cbc766af2c6e";
                options.AuthenticationScheme = "Facebook";
                options.SignInScheme = "Cookies";
                options.Scope.Add("email");
                options.Scope.Add("public_profile");
                options.Scope.Add("user_birthday");
                options.BackchannelHttpHandler = new FacebookBackChannelHandler();
                options.UserInformationEndpoint =
                    "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name,location";
            });

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });

        }
        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
