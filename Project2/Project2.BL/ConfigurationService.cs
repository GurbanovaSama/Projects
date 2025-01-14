using Microsoft.Extensions.DependencyInjection;
using Project2.BL.Services.Abstractions;
using Project2.BL.Services.Concretes;
using System.Reflection;

namespace Project2.BL;

public static class ConfigurationService
{
    public static void AddBLService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ITechnicianService, TechnicianService>();   
    }
}
