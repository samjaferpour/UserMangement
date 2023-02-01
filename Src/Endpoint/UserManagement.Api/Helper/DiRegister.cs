using UserManagement.Application.Services;
using UserManagement.Contract.Interfaces.Repositories;
using UserManagement.Contract.Interfaces.Services;
using UserManagement.Persistence.Repositories;

namespace UserManagement.Api.Helper
{
    public static class DiRegister
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRegisterService, UserRegisterService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IRgenerateTokenService, RgenerateTokenService>();
        }

    }
}
