using OneOf;
using ResultPattern.OneOf.Application.Erros;

namespace ResultPattern.OneOf.Application.Execeptions
{
    public static class OneOffExtensions
    {
        public static bool IsSuccess<TResult>(this OneOf<TResult, AppError> obj) => obj.IsT0;
        public static TResult GetSuccess<TResult>(this OneOf<TResult, AppError> obj) => obj.AsT0;

        public static bool IsError<TResult>(this OneOf<TResult, AppError> obj) => obj.IsT1;
        public static AppError GetError<TResult>(this OneOf<TResult, AppError> obj) => obj.AsT1;
    }
}
