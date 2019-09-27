using System;
using System.Collections.Generic;

namespace JereMath.Library.JereMath
{
    public class Variable : IEquatable<Variable>
    {
        public Expression Expression { get; set; }
        public string Representation { get; set; }
        public bool IsUnknown => !IsKnown;
        public bool IsUnknownNegative { get; set; }
        public bool IsKnown { get; set; }

        public Variable(string representation)
        {
            Representation = representation;
        }

        public Variable(string givenText, string representation)
        {
            Expression = givenText;
            Representation = representation;
            IsKnown = true;
        }
        public Variable(int number, string representation)
        {
            Expression = number;
            Representation = representation;
            IsKnown = true;
        }
        public Variable(long number, string representation)
        {
            Expression = number;
            Representation = representation;
            IsKnown = true;
        }
        public Variable(double number, string representation)
        {
            Expression = number;
            Representation = representation;
            IsKnown = true;
        }
        public Variable(decimal number, string representation)
        {
            Expression = number;
            Representation = representation;
            IsKnown = true;
        }
        public Variable(JereNumber numerator, string representation)
        {
            Expression = numerator;
            Representation = representation;
            IsKnown = true;
        }
        public Variable(Expression expression, string representation)
        {
            Expression = expression;
            Representation = representation;
            IsKnown = true;
        }

        public Variable(int numerator, int denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(int numerator, long denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(int numerator, double denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, (decimal)denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(int numerator, decimal denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(int numerator, JereNumber denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(int numerator, Expression denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }

        public Variable(long numerator, int denominator, string representation)
        {
            Expression = new Expression(new JereNumber((decimal)numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(long numerator, long denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(long numerator, double denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, (decimal)denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(long numerator, decimal denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(long numerator, JereNumber denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(long numerator, Expression denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }

        public Variable(double numerator, int denominator, string representation)
        {
            Expression = new Expression(new JereNumber((decimal)numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(double numerator, long denominator, string representation)
        {
            Expression = new Expression(new JereNumber((decimal)numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(double numerator, double denominator, string representation)
        {
            Expression = new Expression(new JereNumber((decimal)numerator, (decimal)denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(double numerator, decimal denominator, string representation)
        {
            Expression = new Expression(new JereNumber((decimal)numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(double numerator, JereNumber denominator, string representation)
        {
            Expression = new Expression(new JereNumber((decimal)numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(double numerator, Expression denominator, string representation)
        {
            Expression = new Expression(new JereNumber((decimal)numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }

        public Variable(decimal numerator, int denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(decimal numerator, long denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(decimal numerator, double denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, (decimal)denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(decimal numerator, decimal denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(decimal numerator, JereNumber denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(decimal numerator, Expression denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }

        public Variable(Expression numerator, int denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(Expression numerator, long denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(Expression numerator, double denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, (decimal)denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(Expression numerator, decimal denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(Expression numerator, JereNumber denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));
            Representation = representation;
            IsKnown = true;
        }
        public Variable(Expression numerator, Expression denominator, string representation)
        {
            Expression = new Expression(new JereNumber(numerator, denominator));  //TODO review all this for entire page concerning JereNumbers and Expressions, this will truncate more complex stuff
            Representation = representation;
            IsKnown = true;
        }

        //public static Variable operator -(Variable first)
        //{
        //    if (ReferenceEquals(first, null)) throw new ArgumentNullException("first: (operator -)");

        //    var temp = first.Expression?.NormalizeNegatives();
        //    var result = new Variable(-temp.Numerator, temp.Denominator, first.Representation);
        //    return result;
        //}

        //public static Variable operator -(Variable first, Variable second)
        //{
        //    if (ReferenceEquals(first, null)) throw new ArgumentNullException("first: (operator -)");
        //    if (ReferenceEquals(second, null)) throw new ArgumentNullException("second: (operator -)");
        //    if (first.IsUnknown) throw new ArithmeticException("first IsUnknown: (operator -)");
        //    if (second.IsUnknown) throw new ArithmeticException("second IsUnknown: (operator -)");

        //    Variable result;

        //    if (first.IsUnknown || second.IsUnknown)
        //    {
        //        result = new Variable("0,0"); //debatable logic
        //    }
        //    else if (first.Expression.Denominator == second.Expression.Denominator)
        //    {
        //        var top = first.Expression.Numerator - second.Expression.Numerator;
        //        var bottom = first.Expression.Denominator;
        //        result = new Variable(top, bottom, first.Representation);
        //    }
        //    else
        //    {
        //        var top = (first.Expression.Numerator * second.Expression.Denominator) - (first.Expression.Denominator * second.Expression.Numerator);
        //        var bottom = first.Expression.Denominator * second.Expression.Denominator;
        //        result = new Variable(top, bottom, first.Representation);
        //    }

        //    return result;
        //}

        //public static Variable operator --(Variable first)
        //{
        //    if (ReferenceEquals(first, null)) throw new ArgumentNullException("first: (operator --)");
        //    if (first.IsUnknown) throw new ArithmeticException("IsUnknown: (operator --)");

        //    first.Expression = first.Expression--;

        //    return first;
        //}

        //public static Variable operator +(Variable first, Variable second)
        //{
        //    if (ReferenceEquals(first, null)) throw new ArgumentNullException("first: (operator +)");
        //    if (ReferenceEquals(second, null)) throw new ArgumentNullException("second: (operator +)");
        //    if (first.IsUnknown) throw new ArithmeticException("first IsUnknown: (operator +)");
        //    if (second.IsUnknown) throw new ArithmeticException("second IsUnknown: (operator +)");

        //    Variable result;

        //    if (first.IsUnknown || second.IsUnknown)
        //    {
        //        result = new Variable(0, 0, first.Representation);
        //    }
        //    else if (first.Expression.Denominator == second.Expression.Denominator)
        //    {
        //        var top = first.Expression.Numerator + second.Expression.Numerator;
        //        var bottom = first.Expression.Denominator;
        //        result = new Variable(top, bottom, first.Representation);
        //    }
        //    else
        //    {
        //        var top = (first.Expression.Numerator * second.Expression.Denominator) + (first.Expression.Denominator * second.Expression.Numerator);
        //        var bottom = first.Expression.Denominator * second.Expression.Denominator;
        //        result = new Variable(top, bottom, first.Representation);
        //    }

        //    return result;
        //}

        //public static Variable operator ++(Variable first)
        //{
        //    if (ReferenceEquals(first, null)) throw new ArgumentNullException("first: (operator ++)");
        //    if (first.IsUnknown) throw new ArithmeticException("IsUnknown: (operator ++)");

        //    first.Expression = first.Expression++;
        //    return first;
        //}

        //public static Variable operator *(Variable first, Variable second)
        //{
        //    if (ReferenceEquals(first, null)) throw new ArgumentNullException("first: (operator *)");
        //    if (ReferenceEquals(second, null)) throw new ArgumentNullException("second: (operator *)");
        //    if (first.IsUnknown) throw new ArithmeticException("first IsUnknown: (operator *)");
        //    if (second.IsUnknown) throw new ArithmeticException("second IsUnknown: (operator *)");

        //    decimal top = first.Expression.Numerator * second.Expression.Numerator;
        //    decimal bottom = first.Expression.Denominator * second.Expression.Denominator;
        //    Variable result = new Variable(top, bottom, first.Representation);
        //    return result;
        //}

        //public static Variable operator /(Variable first, Variable second)
        //{
        //    if (ReferenceEquals(first, null)) throw new ArgumentNullException("first: (operator /)");
        //    if (first.IsUnknown) throw new ArithmeticException("first IsUnknown: (operator /)");
        //    if (second.IsUnknown) throw new ArithmeticException("second IsUnknown: (operator /)");
        //    if (ReferenceEquals(second, null)) throw new ArgumentNullException("second: (operator /)");

        //    var top = first.Expression.Numerator * second.Expression.Denominator;
        //    var bottom = first.Expression.Denominator * second.Expression.Numerator;
        //    var result = new Variable(top, bottom, first.Representation);
        //    return result;
        //}

        //public static bool operator ==(Variable first, Variable second)
        //{
        //    if (!ReferenceEquals(first, null) && !ReferenceEquals(second, null))
        //    {
        //        if (first.IsUnknown) throw new ArithmeticException("first IsUnknown: (operator ==)");
        //        if (second.IsUnknown) throw new ArithmeticException("second IsUnknown: (operator ==)");

        //        return first.Expression.Numerator == second.Expression.Numerator
        //            && first.Expression.Denominator == second.Expression.Denominator;
        //    }
        //    else if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
        //    {
        //        throw new ArgumentNullException("first and second are both null: (operator ==)");
        //    }
        //    else if (ReferenceEquals(first, null))
        //    {
        //        throw new ArgumentNullException("first: (operator ==)");
        //    }
        //    else if (ReferenceEquals(second, null))
        //    {
        //        throw new ArgumentNullException("second: (operator ==)");
        //    }
        //    else
        //    {
        //        throw new Exception("Hey mun', how'd you get 'ere? (operator ==)");
        //    }
        //}

        //public static bool operator !=(Variable first, Variable second)
        //{
        //    return !(first == second);
        //}

        //public static bool operator <(Variable first, Variable second)
        //{
        //    if (!ReferenceEquals(first, null) && !ReferenceEquals(second, null))
        //    {
        //        if (first.IsUnknown) throw new ArithmeticException("first IsUnknown: (operator <)");
        //        if (second.IsUnknown) throw new ArithmeticException("second IsUnknown: (operator <)");

        //        JereNumber left = first.Expression.Numerator.Numerator * second.Expression.Denominator.Denominator;
        //        JereNumber right = second.Expression.Numerator.Numerator * first.Expression.Denominator.Denominator;

        //        return left < right;
        //    }
        //    else if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
        //    {
        //        throw new ArgumentNullException("first and second are both null: (operator <)");
        //    }
        //    else if (ReferenceEquals(first, null))
        //    {
        //        throw new ArgumentNullException("first: (operator <)");
        //    }
        //    else if (ReferenceEquals(second, null))
        //    {
        //        throw new ArgumentNullException("second: (operator <)");
        //    }
        //    else
        //    {
        //        throw new Exception("Hey bro, how'd you get here? (operator <)");
        //    }
        //}

        //public static bool operator >(Variable first, Variable second)
        //{
        //    if (!ReferenceEquals(first, null) && !ReferenceEquals(second, null))
        //    {
        //        if (first.IsUnknown) throw new ArithmeticException("first IsUnknown: (operator >)");
        //        if (second.IsUnknown) throw new ArithmeticException("second IsUnknown: (operator >)");

        //        JereNumber left = first.Expression.Numerator.Numerator * second.Expression.Denominator.Denominator;
        //        JereNumber right = second.Expression.Numerator.Numerator * first.Expression.Denominator.Denominator;

        //        return left > right;
        //    }
        //    else if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
        //    {
        //        throw new ArgumentNullException("first and second are both null: (operator >)");
        //    }
        //    else if (ReferenceEquals(first, null))
        //    {
        //        throw new ArgumentNullException("first: (operator >)");
        //    }
        //    else if (ReferenceEquals(second, null))
        //    {
        //        throw new ArgumentNullException("second: (operator >)");
        //    }
        //    else
        //    {
        //        throw new Exception("Hey mun', how'd you get 'ere? (operator >)");
        //    }
        //}

        //public static bool operator <=(Variable first, Variable second)
        //{
        //    if (!ReferenceEquals(first, null) && !ReferenceEquals(second, null))
        //    {
        //        if (first.IsUnknown) throw new ArithmeticException("first IsUnknown: (operator <=)");
        //        if (second.IsUnknown) throw new ArithmeticException("second IsUnknown: (operator <=)");

        //        JereNumber left = first.Expression.Numerator.Numerator * second.Expression.Denominator.Denominator;
        //        JereNumber right = second.Expression.Numerator.Numerator * first.Expression.Denominator.Denominator;

        //        return left <= right;
        //    }
        //    else if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
        //    {
        //        throw new ArgumentNullException("first and second are both null: (operator <=)");
        //    }
        //    else if (ReferenceEquals(first, null))
        //    {
        //        throw new ArgumentNullException("first: (operator <=)");
        //    }
        //    else if (ReferenceEquals(second, null))
        //    {
        //        throw new ArgumentNullException("second: (operator <=)");
        //    }
        //    else
        //    {
        //        throw new Exception("Hey mun', how'd you get 'ere? (operator <=)");
        //    }
        //}

        //public static bool operator >=(Variable first, Variable second)
        //{
        //    if (!ReferenceEquals(first, null) && !ReferenceEquals(second, null))
        //    {
        //        if (first.IsUnknown) throw new ArithmeticException("first IsUnknown: (operator >=)");
        //        if (second.IsUnknown) throw new ArithmeticException("second IsUnknown: (operator >=)");

        //        JereNumber left = first.Expression.Numerator.Numerator * second.Expression.Denominator.Denominator;
        //        JereNumber right = second.Expression.Numerator.Numerator * first.Expression.Denominator.Denominator;

        //        return left >= right;
        //    }
        //    else if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
        //    {
        //        throw new ArgumentNullException("first and second are both null: (operator >=)");
        //    }
        //    else if (ReferenceEquals(first, null))
        //    {
        //        throw new ArgumentNullException("first: (operator >=)");
        //    }
        //    else if (ReferenceEquals(second, null))
        //    {
        //        throw new ArgumentNullException("second: (operator >=)");
        //    }
        //    else
        //    {
        //        throw new Exception("Hey mun', how'd you get 'ere? (operator >=)");
        //    }
        //}

        public override bool Equals(object obj)
        {
            return Equals(obj as Variable);
        }

        public bool Equals(Variable other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Representation == other.Representation;
        }

        public override int GetHashCode()
        {
            var hashCode = 1579082726;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Representation);
            return hashCode;
        }
    }
}
