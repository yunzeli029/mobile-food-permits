using Microsoft.Extensions.DependencyInjection;
using MobileFoodPermits.File.Models;
using MobileFoodPermits.File.Services;
using MobileFoodPermits.File.Services.Interfaces;

namespace MobileFoodPermits.File.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddFilePermits(this IServiceCollection services, FileSettings settings)
        {
            services
                .AddLazyCache()
                .AddSingleton(settings)
                .AddTransient<IFileRepository, FileRepository>()
                .AddTransient<IPermitCollectionRepository, PermitCollectionRepository>();

            return services;
        }
    }
}
