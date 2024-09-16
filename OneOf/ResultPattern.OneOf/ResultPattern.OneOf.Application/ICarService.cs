using OneOf;
using ResultPattern.OneOf.Application.Erros;

namespace ResultPattern.OneOf.Application
{
    public interface ICarService
    {
        public Task<OneOf<Car, AppError>> AddCar(string name, CancellationToken ct);
    }
}