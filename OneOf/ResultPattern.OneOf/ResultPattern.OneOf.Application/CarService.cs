using Microsoft.EntityFrameworkCore;
using OneOf;
using ResultPattern.OneOf.Application.Erros;
using ResultPattern.OneOf.Application.Execeptions;

namespace ResultPattern.OneOf.Application
{
    internal class CarService(AppDbContext appDb) : ICarService
    {
        public async Task<OneOf<Car, AppError>> AddCar(string name, CancellationToken ct)
        {
            if (name.StartsWith("M", StringComparison.InvariantCultureIgnoreCase))
                return new ShouldNotStartWithMException();

            // Validating if Already Exists
            var carAlreadyExists = await appDb.Cars.AnyAsync(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase), ct);

            if (carAlreadyExists)
                return new CarNameAlreadyExists();

            var car = new Car(Guid.NewGuid(), name);
            await appDb.Cars.AddAsync(car, ct);
            await appDb.SaveChangesAsync(ct);
            return car;
        }
    }
}