using Entities.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Contract;
using Repository.StoreWayDbContext;
using Service;
using Service.Contract;

namespace StoreWay.ServicesExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreWayContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 23))));
            

        }
        public static void ServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IProductsServices, ProductsServices>();
            services.AddScoped<IUserAdressService, UserAdressService>();
        }
        public static void RepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IUserAdressRepository, UserAdressRepository>();
            
        }
    }
}
