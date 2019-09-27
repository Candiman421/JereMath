using JereMath.Library.JereMath;
using JereMath.Library.JereMath.RegexUtil;
using System;
using System.Collections.Generic;
using System.Text;

namespace JereMath.Library.JereMath.Extensions
{
    public static class TransformationExtensions
    {
        public static Cartesian2DPoints Translate(this Cartesian2DPoints figure, string displacementVectorFormat) // JereNumber|JereNumber
        {
            if (RegexPatterns.DisplacementVector.IsMatch(displacementVectorFormat))
            {
                var dvTemp = new DisplacementVector(displacementVectorFormat);
                var result = (Cartesian2DPoints)Transformation.Translate(figure.Points, dvTemp.TopHorizontal, dvTemp.BottomVertical);
                return result;
            }
            else
            {
                throw new ArgumentException("Must use proper format");
            }
        }

        public static Cartesian2DPoints Translate(this Cartesian2DPoints figure, DisplacementVector displacementVector)
        {
            var result = (Cartesian2DPoints)Transformation.Translate(figure.Points, displacementVector.TopHorizontal, displacementVector.BottomVertical);
            return result;
        }

        public static Cartesian2DPoints Reflect(this Cartesian2DPoints figure, LineType lineType)
        {
            var result = (Cartesian2DPoints)Transformation.Reflect(figure.Points, lineType);
            return result;
        }

        public static Cartesian2DPoints Rotate(this Cartesian2DPoints figure, DegreeType degreeType)
        {
            var result = (Cartesian2DPoints)Transformation.Rotate(figure.Points, degreeType);
            return result;
        }

        public static Cartesian2DPoints Dilate(this Cartesian2DPoints figure, Expression multiplier)
        {
            var result = (Cartesian2DPoints)Transformation.Dilate(figure.Points, multiplier);
            return result;
        }





        public static Expression Translate(this Expression figure, string displacementVectorFormat) // "JereNumber|JereNumber"
        {
            if (RegexPatterns.DisplacementVector.IsMatch(displacementVectorFormat))
            {
                var dvTemp = new DisplacementVector(displacementVectorFormat);
                var result = (Expression)Transformation.Translate(figure.AsFigure2D.Points, dvTemp.TopHorizontal, dvTemp.BottomVertical);
                return result;
            }
            else
            {
                throw new ArgumentException("Must use proper format");
            }
        }

        public static Expression Translate(this Expression figure, DisplacementVector displacementVector)
        {
            var result = (Expression)Transformation.Translate(figure.AsFigure2D.Points, displacementVector.TopHorizontal, displacementVector.BottomVertical);
            return result;
        }

        public static Expression Reflect(this Expression figure, LineType lineType)
        {
            var result = (Expression)Transformation.Reflect(figure.AsFigure2D.Points, lineType);
            return result;
        }

        public static Expression Rotate(this Expression figure, DegreeType degreeType)
        {
            var result = (Expression)Transformation.Rotate(figure.AsFigure2D.Points, degreeType);
            return result;
        }

        public static Expression Dilate(this Expression figure, Expression multiplier)
        {
            var result = (Expression)Transformation.Dilate(figure.AsFigure2D.Points, multiplier);
            return result;
        }
    }
}
