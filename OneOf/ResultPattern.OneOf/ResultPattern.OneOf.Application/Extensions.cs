using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ResultPattern.OneOf.Application
{
    public static class Extensions
    {
        public static void AddAplication(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("MyInMemoryDb"));
        }
    }
}