using PanKunik.Results;

// ReSharper disable once CheckNamespace
namespace DoIt.Domain.Activities;

public static partial class Errors
{
    public static class Descriptions
    {
        public static Error TooLong(int maxLength)
            => Error.Validation(ErrorCodes.Descriptions.TooLong,
                $"Description must not exceed {maxLength} characters.");
    }
}