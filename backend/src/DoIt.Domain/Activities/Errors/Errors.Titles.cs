using PanKunik.Results;

// ReSharper disable once CheckNamespace
namespace DoIt.Domain.Activities;

public static partial class Errors
{
    public static class Titles
    {
        public static Error Empty
            => Error.Validation(ErrorCodes.Titles.Empty, "Title cannot be null, empty or white-space.");

        public static Error TooLong(int maxLength)
            => Error.Validation(ErrorCodes.Titles.TooLong, $"Title must not exceed {maxLength} characters.");
    }
}