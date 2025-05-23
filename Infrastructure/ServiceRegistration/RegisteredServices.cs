using Core.IRepository;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ServiceRegistration
{
    public static class RegisteredServices
    {
        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration Iconfig)
        {
            service.AddDbContext<AppData>(_options =>
            {
                _options.UseSqlServer(Iconfig.GetConnectionString("TestDommyDb"));
            });
            service.AddScoped<IObjectRepository, ObjectRepository>();

            return service;
        }
    }
}
