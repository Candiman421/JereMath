using JereMath.Library.JereMath;
using System;
using System.Collections.Generic;
using System.Text;

namespace JereMath.Library.JereMath.Extensions
{
    public static class PointExtensions
    {
        public static bool IsLine(this List<Point> points)
        {
            if (points.Count >= 3)
            {
                //x1(y2-y3) + x2(y3-y1) + x3(y1-y2)  //or can be written in vector form.. dumbass  //http://mathworld.wolfram.com/Collinear.html
                var notALine = false;
                for (int i = 0; i < points.Count - 2; i++)
                {
                    var step1 = points[i + 0].Xdecimal * points[i + 1].Ydecimal;
                    var step2 = points[i + 0].Xdecimal * points[i + 2].Ydecimal;
                    var step3 = step1 - step2;

                    var step4 = points[i + 1].Xdecimal * points[i + 2].Ydecimal;
                    var step5 = points[i + 1].Xdecimal * points[i + 0].Ydecimal;
                    var step6 = step4 - step5;

                    var step7 = points[i + 2].Xdecimal * points[i + 0].Ydecimal;
                    var step8 = points[i + 2].Xdecimal * points[i + 1].Ydecimal;
                    var step9 = step1 - step2;

                    var step10 = step3 + step6 + step9;

                    if (step10 != 0)
                    {
                        notALine = true;
                        break;
                    }
                }

                return !notALine;
            }
            else
            {
                return points.Count == 2;
            }
        }
    }
}
