namespace Balanzas.Infrastructure
{
    using System.Linq;

    public static class TextTools
    {
        public static string StripNonNumericChars(this string text)
        {
            var goodChars = "0123456789.,".ToCharArray();

            text = text ?? string.Empty;
            return new string(text.Where(p => goodChars.Contains(p)).ToArray());
        }
    }
}