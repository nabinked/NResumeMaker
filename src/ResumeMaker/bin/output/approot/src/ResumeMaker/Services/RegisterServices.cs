using System;
using DbPortal;
using Microsoft.Extensions.DependencyInjection;
using ResumeMaker.Services.Account;
using ResumeMaker.Services.ToastNotification;

namespace ResumeMaker.Services
{
    public class RegisterServices
    {
        public void RegisterServies(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddMvc();
            services.AddScoped<ISignInManager, SignInManager>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IResumeBuilderViewHelper, ResumeBuilderViewHelper>();
            services.AddScoped<User, User>();
            services.AddSingleton<IConnectionFactory, SqlConnectionFactory>();
            services.AddInstance<IToastNotification>(new ToastNotification.ToastNotification());

        }
    }
}
