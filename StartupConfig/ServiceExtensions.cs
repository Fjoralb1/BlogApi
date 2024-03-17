using DevAlApplication.Interface;
using DevAlApplication.Models.GeneralModels;
using DevAlApplication.Repositories;
using DevAlApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace DevAlApplication.StartupConfig
{
    public static class ServiceExtensions
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")); });
        }

        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
