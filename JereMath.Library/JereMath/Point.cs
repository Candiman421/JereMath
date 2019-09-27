using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace JereMath.Library.JereMath
{
    public static class PointExtensions
    {
        public static Point First(this List<Point> Points)
        {
            var pointsArray = Points?.ToArray();
            if (pointsArray.Length >= 1)
            {
                return pointsArray[0];
            }
            else
            {
                return null;
            }
        }
        public static Point Second(this List<Point> Points)
        {
            var pointsArray = Points?.ToArray();
            if (pointsArray.Length >= 2)
            {
                return pointsArray[1];
            }
            else
            {
                return null;
            }
        }
    }


    public class Point : IEquatable<Point>
    {
        public Expression _x;
        public Expression _y;
        public string X => _x.AsNumber?.Representation;
        public string Y => _y.AsNumber?.Representation;
        public decimal? Xdecimal => _x.AsNumber?.Data?.AsDecimal;
        public decimal? Ydecimal => _y.AsNumber?.Data?.AsDecimal;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public Point(int x, long y)
        {
            _x = x;
            _y = y;
        }
        public Point(int x, double y)
        {
            _x = x;
            _y = (decimal)y;
        }
        public Point(int x, decimal y)
        {
            _x = x;
            _y = y;
        }
        public Point(int x, JereNumber y)
        {
            _x = x;
            _y = y;
        }
        public Point(int x, Expression y)
        {
            _x = x;
            _y = y;
        }

        public Point(long x, long y)
        {
            _x = x;
            _y = y;
        }
        public Point(long x, int y)
        {
            _x = x;
            _y = y;
        }
        public Point(long x, double y)
        {
            _x = x;
            _y = (decimal)y;
        }
        public Point(long x, decimal y)
        {
            _x = x;
            _y = y;
        }
        public Point(long x, JereNumber y)
        {
            _x = x;
            _y = y;
        }
        public Point(long x, Expression y)
        {
            _x = x;
            _y = y;
        }

        public Point(double x, double y)
        {
            _x = (decimal)x;
            _y = (decimal)y;
        }
        public Point(double x, int y)
        {
            _x = (decimal)x;
            _y = y;
        }
        public Point(double x, long y)
        {
            _x = (decimal)x;
            _y = y;
        }
        public Point(double x, decimal y)
        {
            _x = (decimal)x;
            _y = y;
        }
        public Point(double x, JereNumber y)
        {
            _x = (decimal)x;
            _y = y;
        }
        public Point(double x, Expression y)
        {
            _x = (decimal)x;
            _y = y;
        }

        public Point(decimal x, decimal y)
        {
            _x = x;
            _y = y;
        }
        public Point(decimal x, int y)
        {
            _x = x;
            _y = y;
        }
        public Point(decimal x, long y)
        {
            _x = x;
            _y = y;
        }
        public Point(decimal x, double y)
        {
            _x = x;
            _y = (decimal)y;
        }
        public Point(decimal x, JereNumber y)
        {
            _x = x;
            _y = y;
        }
        public Point(decimal x, Expression y)
        {
            _x = x;
            _y = y;
        }

        public Point(JereNumber x, JereNumber y)
        {
            _x = x;
            _y = y;
        }
        public Point(JereNumber x, int y)
        {
            _x = x;
            _y = y;
        }
        public Point(JereNumber x, long y)
        {
            _x = x;
            _y = y;
        }
        public Point(JereNumber x, double y)
        {
            _x = x;
            _y = (decimal)y;
        }
        public Point(JereNumber x, decimal y)
        {
            _x = x;
            _y = y;
        }
        public Point(JereNumber x, Expression y)
        {
            _x = x;
            _y = y;
        }

        public Point(Expression x, Expression y)
        {
            _x = x;
            _y = y;
        }
        public Point(Expression x, int y)
        {
            _x = x;
            _y = y;
        }
        public Point(Expression x, long y)
        {
            _x = x;
            _y = y;
        }
        public Point(Expression x, double y)
        {
            _x = x;
            _y = (decimal)y;
        }
        public Point(Expression x, decimal y)
        {
            _x = x;
            _y = y;
        }
        public Point(Expression x, JereNumber y)
        {
            _x = x;
            _y = y;
        }

        public static bool operator ==(Point left, Point right)
        {
            return EqualityComparer<Point>.Default.Equals(left, right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            var other = (Point)obj;

            return _x.Equals(other._x)
                 && _y.Equals(other._y);
        }

        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return _x.Equals(other._x)
                && _y.Equals(other._y);
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + EqualityComparer<Expression>.Default.GetHashCode(_x);
            hashCode = hashCode * -1521134295 + EqualityComparer<Expression>.Default.GetHashCode(_y);
            return hashCode;
        }
    }
}
