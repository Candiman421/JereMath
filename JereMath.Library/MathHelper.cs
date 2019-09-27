
//https://stackoverflow.com/questions/32664/is-there-a-constraint-that-restricts-my-generic-method-to-numeric-types
using System;
namespace JereMath.Library
{
    public class MathHelper
    {
        public static int GreatestCommonDivisor(int a, int b)
        {
            if (a < 1 || b < 1)
            {
                throw new ArgumentException("a or b is less than 1");
            }

            if (b == 0)
            {
                return a;
            }
            else
            {
                return GreatestCommonDivisor(b, a % b);
            }
        }

        // Return the least common multiple of a and b.
        public static int LeastCommonMultiple(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }
            return a * b / GreatestCommonDivisor(a, b);
        }

        public static long GreatestCommonDivisor(long a, long b)
        {
            if (a < 1 || b < 1)
            {
                throw new ArgumentException("a or b is less than 1");
            }

            if (b == 0)
            {
                return a;
            }
            else
            {
                return GreatestCommonDivisor(b, a % b);
            }
        }

        // Return the least common multiple of a and b.
        public static long LeastCommonMultiple(long a, long b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }
            return a * b / GreatestCommonDivisor(a, b);
        }

        public static double GreatestCommonDivisor(double a, double b)
        {
            //if (a < 1 || b < 1)
            //{
            //    throw new ArgumentException("a or b is less than 1");
            //}

            if (b == 0)
            {
                return a;
            }
            else
            {
                return GreatestCommonDivisor(b, a % b);
            }
        }

        // Return the least common multiple of a and b.
        public static double LeastCommonMultiple(double a, double b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }
            return a * b / GreatestCommonDivisor(a, b);
        }
        public static decimal GreatestCommonDivisor(decimal a, decimal b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return GreatestCommonDivisor(b, a % b);
            }
        }

        // Return the least common multiple of a and b.
        public static decimal LeastCommonMultiple(decimal a, decimal b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }
            return a * b / GreatestCommonDivisor(a, b);
        }

    }
}