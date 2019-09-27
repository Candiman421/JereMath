using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using JereMath.Library.JereMath.RegexUtil;
using JereMath.Library.JereMath.Extensions;

namespace JereMath.Library.JereMath
{
    //public static class LineExtensions
    //{
    //    /// <summary>
    //    ///  Returns Slope (m) from 2 given points
    //    /// </summary>
    //    /// <param name="line"></param>
    //    /// <param name="a">(x,y)</param>
    //    /// <param name="b">(x,y)</param>
    //    /// <returns></returns>
    //    public static Expression SlopeFormula(this Line line, Point p1, Point p2)
    //    {
    //        //Slope formula m = y2-y1 / x2-x1
    //        var top = p2.Y - p1.Y;
    //        var bottom = p2.X - p1.X;
    //        var m = new Expression(top, bottom);
    //        return m;
    //    }
    //}
    public class Line
    {
        public List<Point> Points { get; set; } = new List<Point>();
        public bool IsValidLine => Points.IsLine();
        public Point Y_Intercept { get; set; }
        public Variable Y { get; set; }
        public Variable M { get; set; }  //Slope
        public Expression Slope => (decimal)M?.Expression; //can be fraction
        public Variable X { get; set; }
        public Variable B { get; set; }  //YiIntercept

        //public Expression Rise { get; set; }
        //public Expression Run { get; set; }
        public Expression RiseOverRun { get; set; }
        public Point Point1 => Points.First();
        public Point Point2 => Points.Second();

        public Line(string listPoints)
        {
            if (RegexPatterns.Point2DList.IsMatch(listPoints))
            {
                List<Dictionary<string, string>> namedCaptures = RegexPatterns.Point2DList.MatchNamedCapturesCollection(listPoints);
                Points.AddRange(from pair in namedCaptures
                                let x = new Expression(pair["x"])
                                let y = new Expression(pair["y"])
                                select new Point(x, y));
            }
        }

        public Line(List<Point> points)
        {
            if (points.IsLine())
            {
                Points = points;
            }
            else
            {
                //grrrrrr
            }
        }



        public void FindSlope()
        {
            SlopeFormula();
        }
        public void SlopeFormula()
        {
            //Slope formula m = y2-y1 / x2-x1
            Expression top = Point2._y - Point1._y;
            Expression bottom = Point2._x - Point1._x;
            M = new Variable(top, bottom, "m"); ;
        }

        public void FindYIntercept() //https://www.wikihow.com/Find-the-Y-Intercept
        {
            if (Point1 != null && Point2 != null)
            {
                SetRiseOverRun();
                decimal? temp = Slope * Point1._x;
                temp = Point1._y - temp;
                B = new Variable((decimal)temp, "b");
            }
            else if (Point1 != null && !ReferenceEquals(M, null))
            {
                //y=mx+b  given slope 2  (3,4)
                //4=2(3)+b
                //slope * x
                decimal? temp = Slope * Point1._x;
                temp = Point1._y - temp;
                B = new Variable((decimal)temp, "b");
            }
            //else if(valid equation)

            PointSlopeForm();
        }
        public void PointSlopeForm()
        {
            //Point-slope form  y - y1 = m(x-x1)
            //var test = Y -
        }

        public void SetRiseOverRun()
        {
            Expression num = Point2._y - Point1._y;
            Expression denom = Point2._x - Point1._x;

            RiseOverRun = new Expression($"{num.Representation}/{denom.Representation}"); //TODO fix this hack, limit is single level Fraction
            M = new Variable(RiseOverRun, "m");
        }
    }


    public class Slope
    {
        public Expression y1 { get; set; }
        public Expression y2 { get; set; }
        public Expression x1 { get; set; }
        public Expression x2 { get; set; }
        public Expression m { get; set; }
        public Expression b { get; set; }
    }
}
