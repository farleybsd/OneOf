using ResultPattern.OneOf.Application.Erros;

namespace ResultPattern.OneOf.Application.Execeptions
{
    public record ShouldNotStartWithMException() : AppError("Should not start with [M]", ErrorType.Validation,nameof(ShouldNotStartWithMException));
    public record CarNameAlreadyExists() : AppError("Car Name Already Exists", ErrorType.BusinessRuler,nameof(CarNameAlreadyExists));
}