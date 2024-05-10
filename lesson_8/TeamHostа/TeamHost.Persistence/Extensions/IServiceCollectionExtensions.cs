using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TeamHost.Application.Interfaces;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Persistence.Contexts;
using TeamHost.Persistence.Repositories;


namespace TeamHost.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

         public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
         {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

         }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IGameRepository, GameRepository>()
                .AddTransient<ILoginRepository, LoginRepository>();
        }
        
     
    }
}
