using System.Linq;

namespace JereMath.Library.JereMath.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal ParseDecimal(this string value, decimal defaultDecimalValue = 0)
        {
            return decimal.TryParse(value, out decimal parsedDecimal) ? parsedDecimal : defaultDecimalValue;
        }

        public static decimal? ParseNullableDecimal(this string value)
        {
            return string.IsNullOrEmpty(value) ? null : (decimal?)value.ParseDecimal();
        }

        public static bool IsNegative(this decimal value)
        {
            return value < 0;
        }
        public static bool IsNegative(this decimal? value)
        {
            return value != null && value < 0;
        }

        //good enough for now, just count digits
        public static int SignificantDigits(this decimal value) //http://csharphelper.com/blog/2016/07/display-significant-digits-in-c/
        {
            return value.ToString().Replace(",", "").Replace(".", "").Trim('0').Length;
        }
        //good enough for now, just count digits
        public static int SignificantDigits(this decimal? value)
        {
            return value.ToString().Replace(",", "").Replace(".", "").Trim('0').Length;
        }

        public static int Scale(this decimal value) //https://stackoverflow.com/questions/13477689/find-number-of-decimal-places-in-decimal-value-regardless-of-culture
        {
            return value.ToString(System.Globalization.CultureInfo.InvariantCulture)
                    .TrimEnd('0')
                    .SkipWhile(c => c != '.')
                    .Skip(1)
                    .Count();
        }
    }
}
