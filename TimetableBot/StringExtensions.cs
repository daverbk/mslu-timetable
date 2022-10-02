namespace TimetableBot;

public static class StringExtensions
{
    public static string? FirstLetterToLower(this string? str)
    {
        const int fromSecondLetter = 1;

        return string.IsNullOrEmpty(str) ? null : new string(str.First()
            .ToString()
            .ToLower()
            .Concat(str.Substring(fromSecondLetter))
            .ToArray());
    }
}
