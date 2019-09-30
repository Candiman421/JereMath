namespace JereMath.Library.JereMath.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveFirst(this string givenText)
        {
            return givenText.Substring(1, givenText.Length - 1);
        }

        public static string RemoveLast(this string givenText)
        {
            return givenText.Substring(0, givenText.Length - 1);
        }
    }
}
