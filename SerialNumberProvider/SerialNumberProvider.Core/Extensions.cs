using Microsoft.Extensions.DependencyInjection;
using SerialNumberProvider.Core.Services.Abstract;
using SerialNumberProvider.Core.Services.Concrete;

namespace SerialNumberProvider.Core
{
    public static class Extensions
    {
        public static IServiceCollection RegisterCoreServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISerialNumberGenerator, SerialNumberGenerator>();
            serviceCollection.AddTransient<IShaCalculator, ShaCalculator>();
            serviceCollection.AddTransient<ISerialNumberValidator, SerialNumberValidator>();
            
            return serviceCollection;
        }
    }
}