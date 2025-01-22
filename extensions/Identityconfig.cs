using Microsoft.AspNetCore.Identity;

namespace ZapAgenda_api_aspnet.extensions
{
    public static class Identityconfig
    {
        public static IServiceCollection ConfigureIdentityOptions(this IServiceCollection services) {
            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;

                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.AllowedForNewUsers =  false;

                options.User.RequireUniqueEmail = false;
            });
            return services;
        }
        
    }
}