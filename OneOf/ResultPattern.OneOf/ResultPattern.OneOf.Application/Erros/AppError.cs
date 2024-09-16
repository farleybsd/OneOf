namespace ResultPattern.OneOf.Application.Erros
{
    public record AppError(string Detail, ErrorType ErrorType,string ErrorCodeName);
}