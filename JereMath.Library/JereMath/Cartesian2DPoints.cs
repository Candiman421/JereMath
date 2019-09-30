using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JereMath.Library.JereMath.RegexUtil;
using JereMath.Library.JereMath.Extensions;
using System.Text.RegularExpressions;
using JereMath.Library.JereMath.Enums;

namespace JereMath.Library.JereMath
{
    public class Cartesian2DPoints : IEquatable<Cartesian2DPoints>
    {
        public List<Point> Points { get; set; } = new List<Point>();

        public Point AsPoint { get; set; }
        public Line AsLine { get; set; }
        public bool As2dFigure { get; set; }
        public bool AsTriangle { get; set; }
        public bool AsFourSided { get; set; }
        public bool IsIrregularFigure { get; set; }

        public Cartesian2DPoints(List<Point> listPoints)
        {
            Points = listPoints;
            AnalyzePoints();
        }

        public Cartesian2DPoints(string listPoints) //(pointX,pointY)(pointX,pointY)(pointX,pointY)
        {
            try
            {
                if (RegexPatterns.Point2DList.IsMatch(listPoints))// "(1,2)(1/2,1 3/4))(-.24,35.23)  <--- 1 or more points allowed, following Number format
                {
                    List<string> captures = RegexPatterns.Point2DList.GetCapturesByGroupName(listPoints, RegexCaptureName.point2dList);
                    if (captures != null)
                    {
                        Points.AddRange(from capture in captures
                                        let pair = capture.RemoveOuterParenthesis()
                                        let singles = pair.Split(',')
                                        let x = new Expression(singles[0])
                                        let y = new Expression(singles[1])
                                        let newPoint = new Point(x, y)
                                        select newPoint);
                        //foreach(var capture in captures)
                        //{
                        //    string pair = capture.RemoveOuterParenthesis();
                        //    string[] singles = pair.Split(',');
                        //    Expression x = new Expression(singles[0]);
                        //    Expression y = new Expression(singles[1]);
                        //    Point newPoint = new Point(x, y);
                        //    Points.Add(newPoint);
                        //}
                    }
                    else
                    {
                        throw new Exception($"Cartesian2DPoints: No captures found");
                    }
                }
                else
                {
                    throw new Exception($"Cartesian2DPoints: Must use valid format for Point2DList instead of: {listPoints}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            AnalyzePoints();
        }

        private void AnalyzePoints()
        {
            if (Points.Count == 1)
            {
                AsPoint = new Point(Points[0]._x, Points[0]._y);
            }
            else if (Points.IsLine())
            {
                AsLine = new Line(Points);
            }
            else
            {
                As2dFigure = true;
                //TODO: evaluate named 2dFigures here
            }
        }

        public static implicit operator Cartesian2DPoints(string pointsList)
        {
            return new Cartesian2DPoints(pointsList);
        }
        public static explicit operator Cartesian2DPoints(List<Point> pointsList)
        {
            return new Cartesian2DPoints(pointsList);
        }

        public static bool operator ==(Cartesian2DPoints left, Cartesian2DPoints right)
        {
            try
            {
                if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) throw new ArgumentNullException("left And right: (operator ==)");
                if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (operator ==)");
                if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (operator ==)");
                else
                {
                    var res = left.Points.Count == right.Points.Count && !left.Points.Except(right.Points).Any();
                    return res;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool operator !=(Cartesian2DPoints left, Cartesian2DPoints right)
        {
            return !(left == right);
        }

        bool IEquatable<Cartesian2DPoints>.Equals(Cartesian2DPoints right)
        {
            try
            {
                if (ReferenceEquals(this, null) && ReferenceEquals(right, null)) throw new ArgumentNullException("Figure2D: left And right: (Equals)");
                if (ReferenceEquals(this, null)) return false;
                if (ReferenceEquals(right, null)) return false;
                else
                {
                    var res = Points.Count == right.Points.Count && !Points.Except(right.Points).Any();
                    return res;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            Cartesian2DPoints right = new Cartesian2DPoints(obj.ToString());
            var res = Points.Count == right.Points.Count && !Points.Except(right.Points).Any();
            return res;
        }
        public override int GetHashCode()
        {
            var hashCode = -1534900553;
            hashCode = hashCode * -1521134295 + Points.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var point in Points)
            {
                sb.Append($"({point.X},{point.Y})");
            }
            return sb.ToString();
        }
    }
}
