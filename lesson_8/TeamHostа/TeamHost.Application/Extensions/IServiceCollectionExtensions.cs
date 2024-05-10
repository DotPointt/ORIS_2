using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace TeamHost.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //services.AddAutoMapper();
            services.AddMediator();
            services.AddValidators();
        }

        // private static void AddAutoMapper(this IServiceCollection services)
        // {
        //     services.AddAutoMapper(typeof(GameProfile));
        // }

        private static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
