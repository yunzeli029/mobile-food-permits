using Microsoft.Extensions.DependencyInjection;
using MobileFoodPermits.File.Models;
using MobileFoodPermits.File.Services;
using MobileFoodPermits.File.Services.Interfaces;

namespace MobileFoodPermits.File
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddFoodPermitFileServices(this IServiceCollection services, FileSettings settings)
        {
            services
                .AddLazyCache()
                .AddSingleton(settings)
                .AddTransient<IFileRepository, CSVFileRepository>()
                .AddTransient<IFoodPermitCollectionRepository, FoodPermitCollectionRepository>()
                .AddTransient<IFoodPermitsProvider, FoodPermitsProvider>();

            return services;
        }
    }
}
