namespace DoIt.Domain.Unit.Tests.Utilities;

public static class RandomHelper
{
    public static string String(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var result = new char[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = chars[Random.Shared.Next(chars.Length)];
        }

        return new string(result);
    }

    public static bool Boolean()
        => Random.Shared.Next(2) % 2 == 0;
}