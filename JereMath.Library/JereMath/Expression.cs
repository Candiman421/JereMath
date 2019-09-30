using JereMath.Library.JereMath.RegexUtil;
using System;
using System.Collections.Generic;

namespace JereMath.Library.JereMath
{
    public class Expression : IEquatable<Expression>
    {
        public string OriginalForm { get; set; }  // 1    2.3    3/4    3 3/4   3(3/4)    2xy^2   3(4 +ab)^3    14/3|3/5   y=mx+b

        public string Representation { get; set; }

        public JereNumber AsNumber { get; set; }
        public bool IsNumber { get; set; }

        public Cartesian2DPoints AsCartesian2dPoints { get; set; }
        public bool IsCartesian2dPoints { get; set; }

        public DisplacementVector AsDisplacementVector { get; set; }
        public bool IsDisplacementVector { get; set; }

        public bool IsComplex { get; set; }   //todo as more complicated algebraic forms

        public Expression(string originalForm)
        {
            OriginalForm = originalForm;

            if (RegexPatterns.MixedNumberOrFractionOrNumber.IsMatch(originalForm))
            {
                AsNumber = new JereNumber(originalForm);
                IsNumber = true;
                Representation = AsNumber.Representation;
            }
            else if (RegexPatterns.Point2DList.IsMatch(originalForm))
            {
                AsCartesian2dPoints = new Cartesian2DPoints(originalForm);
                IsCartesian2dPoints = true;
                Representation = AsCartesian2dPoints.ToString();
            }
            else if (RegexPatterns.DisplacementVector.IsMatch(originalForm))
            {
                AsDisplacementVector = new DisplacementVector(originalForm);
                IsDisplacementVector = true;
            }
            else
            {
                throw new NotImplementedException("wurkin on it");
            }
        }

        public static Expression operator -(Expression right)
        {
            try
            {
                if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (operator -)");

                if (right.IsNumber)
                {
                    return new Expression((-right.AsNumber).ToString());
                }
                else if (right.IsCartesian2dPoints)
                {
                    throw new NotImplementedException("IsFigure2D Expressions here. (operator -)");
                }
                else if (right.IsComplex)
                {
                    throw new NotImplementedException("IsComplex Expressions here. (operator -)");
                }
                else { throw new Exception("Expression:  (operator -)"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static Expression operator -(Expression left, Expression right)
        {
            try
            {
                if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) throw new ArgumentNullException("left And right: (operator -)");
                if (ReferenceEquals(left, null)) return null;
                if (ReferenceEquals(right, null)) return null;

                if (left.IsNumber && right.IsNumber)
                {
                    return new Expression((left.AsNumber - right.AsNumber).ToString());
                }
                else if (left.IsCartesian2dPoints && right.IsCartesian2dPoints)
                {
                    throw new NotImplementedException("IsFigure2D Expressions here. (operator -)");
                }
                else if (left.IsComplex)
                {
                    throw new NotImplementedException("IsComplex Expressions here. (operator -)");
                }
                else { throw new Exception("Expression:  (operator -)"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static Expression operator +(Expression left, Expression right)
        {
            try
            {
                if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) throw new ArgumentNullException("left And right: (operator +)");
                if (ReferenceEquals(left, null)) return null;
                if (ReferenceEquals(right, null)) return null;

                if (left.IsNumber && right.IsNumber)
                {
                    return new Expression((left.AsNumber + right.AsNumber).ToString());
                }
                else if (left.IsCartesian2dPoints && right.IsCartesian2dPoints)
                {
                    throw new NotImplementedException("IsFigure2D Expressions here. (operator +)");
                }
                else if (left.IsComplex)
                {
                    throw new NotImplementedException("IsComplex Expressions here. (operator +)");
                }
                else { throw new Exception("Expression:  (operator +)"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static Expression operator *(Expression left, Expression right)
        {
            try
            {
                if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) throw new ArgumentNullException("left And right: (operator *)");
                if (ReferenceEquals(left, null)) return null;
                if (ReferenceEquals(right, null)) return null;

                if (left.IsNumber && right.IsNumber)
                {
                    return new Expression((left.AsNumber * right.AsNumber).ToString());
                }
                else if (left.IsCartesian2dPoints && right.IsCartesian2dPoints)
                {
                    throw new NotImplementedException("IsFigure2D Expressions here. (operator *)");
                }
                else if (left.IsComplex)
                {
                    throw new NotImplementedException("IsComplex Expressions here. (operator *)");
                }
                else { throw new Exception("Expression:  (operator *)"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static Expression operator /(Expression left, Expression right)
        {
            try
            {
                if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) throw new ArgumentNullException("left And right: (operator /)");
                if (ReferenceEquals(left, null)) return null;
                if (ReferenceEquals(right, null)) return null;

                if (left.IsNumber && right.IsNumber)
                {
                    return new Expression((left.AsNumber / right.AsNumber).ToString());
                }
                else if (left.IsCartesian2dPoints && right.IsCartesian2dPoints)
                {
                    throw new NotImplementedException("IsFigure2D Expressions here. (operator /)");
                }
                else if (left.IsComplex)
                {
                    throw new NotImplementedException("IsComplex Expressions here. (operator /)");
                }
                else { throw new Exception("Expression:  (operator /)"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static bool operator ==(Expression left, Expression right)
        {
            try
            {
                if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) throw new ArgumentNullException("left And right: (operator ==)");
                if (ReferenceEquals(left, null)) throw new ArgumentNullException("left And right: (operator ==)");
                if (ReferenceEquals(right, null)) throw new ArgumentNullException("left And right: (operator ==)");

                if (left.IsNumber && right.IsNumber)
                {
                    return left.AsNumber == right.AsNumber;
                }
                else if (left.IsCartesian2dPoints && right.IsCartesian2dPoints)
                {
                    return left.IsCartesian2dPoints == right.IsCartesian2dPoints;
                }
                else if (left.IsComplex)
                {
                    throw new NotImplementedException("IsComplex Expressions here. (operator ==)");
                }
                else { throw new Exception("Expression:  (operator ==)"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool operator !=(Expression left, Expression right)
        {
            return !(left == right);
        }
        public static bool operator <(Expression left, Expression right)
        {
            try
            {
                if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) throw new ArgumentNullException("left And right: (operator <)");
                if (ReferenceEquals(left, null)) return false;
                if (ReferenceEquals(right, null)) return false;

                if (left.IsNumber && right.IsNumber)
                {
                    return left.AsNumber < right.AsNumber;
                }
                else if (left.IsCartesian2dPoints && right.IsCartesian2dPoints)
                {
                    throw new NotImplementedException("IsFigure2D Expressions here. (operator <)");
                }
                else if (left.IsComplex)
                {
                    throw new NotImplementedException("IsComplex Expressions here. (operator <)");
                }
                else { throw new Exception("Expression:  (operator <)"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool operator >(Expression left, Expression right)
        {
            try
            {
                if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) throw new ArgumentNullException("left And right: (operator >)");
                if (ReferenceEquals(left, null)) return false;
                if (ReferenceEquals(right, null)) return false;

                if (left.IsNumber && right.IsNumber)
                {
                    return left.AsNumber > right.AsNumber;
                }
                else if (left.IsCartesian2dPoints && right.IsCartesian2dPoints)
                {
                    throw new NotImplementedException("IsFigure2D Expressions here. (operator >)");
                }
                else if (left.IsComplex)
                {
                    throw new NotImplementedException("IsComplex Expressions here. (operator >)");
                }
                else { throw new Exception("Expression:  (operator >)"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool operator <=(Expression left, Expression right)
        {
            try
            {
                if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) throw new ArgumentNullException("left And right: (operator <=)");
                if (ReferenceEquals(left, null)) return false;
                if (ReferenceEquals(right, null)) return false;

                if (left.IsNumber && right.IsNumber)
                {
                    return left.AsNumber <= right.AsNumber;
                }
                else if (left.IsCartesian2dPoints && right.IsCartesian2dPoints)
                {
                    throw new NotImplementedException("IsFigure2D Expressions here. (operator <=)");
                }
                else if (left.IsComplex)
                {
                    throw new NotImplementedException("IsComplex Expressions here. (operator <=)");
                }
                else { throw new Exception("Expression:  (operator <=)"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool operator >=(Expression left, Expression right)
        {
            try
            {
                if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) throw new ArgumentNullException("left And right: (operator >=)");
                if (ReferenceEquals(left, null)) return false;
                if (ReferenceEquals(right, null)) return false;

                if (left.IsNumber && right.IsNumber)
                {
                    return left.AsNumber >= right.AsNumber;
                }
                else if (left.IsCartesian2dPoints && right.IsCartesian2dPoints)
                {
                    throw new NotImplementedException("IsFigure2D Expressions here. (operator >=)");
                }
                else if (left.IsComplex)
                {
                    throw new NotImplementedException("IsComplex Expressions here. (operator >=)");
                }
                else { throw new Exception("Expression:  (operator >=)"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static implicit operator Expression(string _string)
        {
            return new Expression(_string);
        }
        public static implicit operator Expression(int _int)
        {
            return new Expression(_int.ToString());
        }
        public static implicit operator Expression(long _long)
        {
            return new Expression(_long.ToString());
        }
        public static implicit operator Expression(double _double)
        {
            return new Expression(_double.ToString());
        }
        public static implicit operator Expression(decimal _decimal)
        {
            return new Expression(_decimal.ToString());
        }
        public static implicit operator Expression(JereNumber _number)
        {
            return new Expression(_number.ToString());
        }
        public static implicit operator Expression(List<Point> _points) //line?
        {
            return new Expression(new Cartesian2DPoints(_points).ToString());
        }
        public static implicit operator Expression(Cartesian2DPoints cartesian2D) //line?
        {
            return new Expression(cartesian2D.ToString());
        }

        public static implicit operator string(Expression right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (implicit Expression to string)");

            return right.Representation;
        }
        public static implicit operator int(Expression right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (implicit Expression to int)");

            if (right.IsNumber)
            {
                return right.AsNumber;
            }
            else
            {
                throw new NotImplementedException("right: (implicit Expression to int)");
            }
        }
        public static implicit operator int?(Expression right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (implicit Expression to int?)");

            if (right.IsNumber)
            {
                return right.AsNumber;
            }
            else
            {
                throw new NotImplementedException("right: (implicit Expression to int?)");
            }
        }
        public static implicit operator long(Expression right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (implicit Expression to long)");

            if (right.IsNumber)
            {
                return right.AsNumber;
            }
            else
            {
                throw new NotImplementedException("right: (implicit Expression to long)");
            }
        }
        public static implicit operator long?(Expression right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (implicit Expression to long?)");

            if (right.IsNumber)
            {
                return right.AsNumber;
            }
            else
            {
                throw new NotImplementedException("right: (implicit Expression to long?)");
            }
        }
        public static implicit operator double(Expression right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (implicit Expression to double)");

            if (right.IsNumber)
            {
                return right.AsNumber;
            }
            else
            {
                throw new NotImplementedException("right: (implicit Expression to double)");
            }
        }
        public static implicit operator double?(Expression right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (implicit Expression to double?)");

            if (right.IsNumber)
            {
                return right.AsNumber;
            }
            else
            {
                throw new NotImplementedException("right: (implicit Expression to double?)");
            }
        }
        public static implicit operator decimal(Expression right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (implicit Expression to decimal)");

            if (right.IsNumber)
            {
                return right.AsNumber;
            }
            else
            {
                throw new NotImplementedException("right: (implicit Expression to decimal)");
            }
        }
        public static implicit operator decimal?(Expression right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (implicit Expression to decimal?)");

            if (right.IsNumber)
            {
                return right.AsNumber;
            }
            else
            {
                throw new NotImplementedException("right: (implicit Expression to decimal?)");
            }
        }
        public static implicit operator JereNumber(Expression right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (implicit Expression to JereNumber)");

            if (right.IsNumber)
            {
                return right.AsNumber;
            }
            else
            {
                throw new NotImplementedException("right: (implicit Expression to JereNumber)");
            }
        }
        public static implicit operator Cartesian2DPoints(Expression right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (implicit Expression to Figure2D)");

            if (right.IsCartesian2dPoints)
            {
                return right.AsCartesian2dPoints;
            }
            else
            {
                throw new NotImplementedException("right: (implicit Expression to Figure2D)");
            }
        }
        public static implicit operator DisplacementVector(Expression right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (implicit Expression to DisplacementVector)");

            if (right.IsDisplacementVector)
            {
                return right.AsDisplacementVector;
            }
            else
            {
                throw new NotImplementedException("right: (implicit Expression to DisplacementVector)");
            }
        }

        bool IEquatable<Expression>.Equals(Expression right)
        {
            return this == right;
        }
        public override bool Equals(object obj)
        {
            if (IsNumber)
            {
                var result = AsNumber.Representation == obj.ToString();
                return result;
            }
            else if (IsCartesian2dPoints)
            {
                var result = AsCartesian2dPoints.ToString() == obj.ToString();
                return result;
            }
            else if (IsComplex)
            {
                throw new NotImplementedException("gettin there");
            }
            else
            {
                throw new Exception("quit trying me boy...");
            }
        }
        public override int GetHashCode()
        {
            int hashCode = -1534900553;
            hashCode = hashCode * -1521134295 + Representation.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Representation;
        }
    }
}
