using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JereMath.Library.JereMath
{
    public static class TransformationHelpers
    {

    }

    public static class Transformation
    {
        public static List<Point> Translate(List<Point> points, Expression a, Expression b)
        {
            //(x,y) = (x + a, x + b)
            var newPoints = new List<Point>();
            foreach (var point in points)
            {
                var x = point._x + a;
                var y = point._y + b;
                newPoints.Add(new Point(x, y));
                //newPoints.Add(new Point(point.X + a, point.Y + b));
            }
            return newPoints;
            //return points.Select(point => new Point(point._x + a, point._y + b)).ToList();
        }

        public static List<Point> Reflect(List<Point> points, LineType lineType)
        {
            //x-axis: (x,y) = (x,-y)
            //y-axis: (x,y) = (-x,y)
            //y =  x: (x,y) = (y,x)
            //y = -x: (x,y) = (-y,-x)
            var newPoints = new List<Point>();
            switch (lineType)
            {
                case LineType.X_axis:
                    newPoints.AddRange(points.Select(point => new Point(point._x, -point._y)));
                    break;
                case LineType.Y_axis:
                    newPoints.AddRange(points.Select(point => new Point(-point._x, point._y)));
                    break;
                case LineType.Y_equals_X:
                    newPoints.AddRange(points.Select(point => new Point(point._y, point._x)));
                    break;
                case LineType.Y_equals_NegativeX:
                    newPoints.AddRange(points.Select(point => new Point(-point._y, -point._x)));
                    break;
                default:
                    throw new ArgumentException("Needs Valid LineType");
            }
            return newPoints;
        }

        public static List<Point> Rotate(List<Point> points, DegreeType degreeType) //TODO update to any degree
        {
            var newPoints = new List<Point>();
            switch (degreeType)
            {
                case DegreeType.CW_90:
                case DegreeType.CCW_270:
                    newPoints.AddRange(points.Select(point => new Point(point._y, -point._x)));
                    break;
                case DegreeType.CCW_90:
                case DegreeType.CW_270:
                    newPoints.AddRange(points.Select(point => new Point(-point._y, point._x)));
                    break;
                case DegreeType.CW_180:
                case DegreeType.CCW_180:
                    newPoints.AddRange(points.Select(point => new Point(-point._x, -point._y)));
                    break;
                default:
                    throw new ArgumentException("Needs Valid DegreeType");
            }
            return newPoints;
        }

        public static List<Point> Dilate(List<Point> points, Expression multiplier)
        {
            //(x,y) = (kx , ky)
            return points.Select(point => new Point(multiplier * point._x, multiplier * point._y)).ToList();
        }

    }
    public enum LineType
    {
        X_axis,
        Y_axis,
        Y_equals_X,
        Y_equals_NegativeX
    }

    public enum DegreeType
    {
        CW_90,
        CCW_90,
        CW_270,
        CCW_270,
        CW_180,
        CCW_180
    }
}
