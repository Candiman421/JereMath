﻿
using JereMath.Library.JereMath;
using JereMath.Library.JereMath.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace JereMath.Tests
{
    [TestClass]
    public class TransformationTests
    {
        [DataTestMethod]
        public void Translate()
        {
            Cartesian2DPoints figure = new Cartesian2DPoints(new List<Point> { new Point(2, 5), new Point(1, 3), new Point(4, 2) });
            figure = figure.Translate(new DisplacementVector(4, -1));
            Cartesian2DPoints expectedFigure = new Cartesian2DPoints(new List<Point> { new Point(6, 4), new Point(5, 2), new Point(8, 1) });
            Assert.AreEqual(figure, expectedFigure);
        }

        [DataTestMethod]
        public void TranslateConcise()
        {
            Cartesian2DPoints transformedFigure = new Cartesian2DPoints("(2,5)(1,3)(4,2)").Translate("4|-1");
            Cartesian2DPoints expectedFigure = new Cartesian2DPoints("(6,4)(5,2)(8,1)");
            Assert.AreEqual(transformedFigure, expectedFigure);
        }

        [DataTestMethod]
        public void TranslateAsExpression()
        {
            Expression transformedFigure = new Expression("(2,5)(1,3)(4,2)").Translate("4|-1");
            Expression expectedFigure = new Expression("(6,4)(5,2)(8,1)");
            Assert.AreEqual(transformedFigure, expectedFigure);
        }

        [DataTestMethod]
        public void TranslateAsCartesian2dAgainstExpression()
        {
            Cartesian2DPoints transformedFigure = new Cartesian2DPoints("(2,5)(1,3)(4,2)").Translate("4|-1");
            Expression expectedFigure = new Expression("(6,4)(5,2)(8,1)");
            Assert.AreEqual(transformedFigure, expectedFigure);
        }

        [DataTestMethod]
        public void TranslateAsCartesian2dImplicitlyConvertedToExpression()
        {
            Expression transformedFigure = new Cartesian2DPoints("(2,5)(1,3)(4,2)").Translate("4|-1");
            Expression expectedFigure = new Cartesian2DPoints("(6,4)(5,2)(8,1)");
            Assert.AreEqual(transformedFigure, expectedFigure);
        }

        [DataTestMethod]
        public void TranslateExpressionComparedToString()
        {
            Expression transformedFigure = new Cartesian2DPoints("(2,5)(1,3)(4,2)").Translate("4|-1");
            Assert.AreEqual(transformedFigure, "(6,4)(5,2)(8,1)");
        }

        [DataTestMethod]  //FAILS
        public void TranslateExpressionComparedToStringFlippedAreEqualArguments()
        {
            Expression transformedFigure = new Cartesian2DPoints("(2,5)(1,3)(4,2)").Translate("4|-1");
            Assert.AreEqual("(6,4)(5,2)(8,1)", transformedFigure);
        }





        [DataTestMethod]
        public void Reflect()
        {
            Cartesian2DPoints figure = new Cartesian2DPoints("(-1,2)(-2,1)(-1,-1)").Reflect(LineType.Y_axis);
            Cartesian2DPoints expectedFigure = new Cartesian2DPoints("(1,2)(2,1)(1,-1)");
            Assert.AreEqual(figure, expectedFigure);
        }

        [DataTestMethod]
        public void ReflectAsExpression()
        {
            Expression figure = new Expression("(-1,2)(-2,1)(-1,-1)").Reflect(LineType.Y_axis);
            Assert.AreEqual(figure, "(1,2)(2,1)(1,-1)");
        }

        [DataTestMethod]
        public void Rotate()
        {
            var figure = new Cartesian2DPoints(new List<Point>{new Point(-1,2),
                                                               new Point(-2,1),
                                                               new Point(-1,-1)});

            figure = figure.Rotate(DegreeType.CW_90);

            var expectedFigure = new Cartesian2DPoints(new List<Point>{new Point(2,1),
                                                               new Point(1,2),
                                                               new Point(-1,1)});
            Assert.AreEqual(figure, expectedFigure);
        }

        [DataTestMethod]
        public void RotateAsExpression()
        {
            var figure = new Expression("(-1,2)(-2,1)(-1,-1)").Rotate(DegreeType.CW_90);
            Assert.AreEqual(figure, "(2,1)(1,2)(-1,1)");
        }

        [DataTestMethod]
        public void Dilate()
        {
            var figure = new Cartesian2DPoints(new List<Point>{new Point(-1,2),
                                                               new Point(-2,1),
                                                               new Point(-1,-1)});
            figure = figure.Dilate(4);
            var expectedFigure = new Cartesian2DPoints(new List<Point>{new Point(-4,8),
                                                               new Point(-8,4),
                                                               new Point(-4,-4)});
            Assert.AreEqual(figure, expectedFigure);
        }

        [DataTestMethod]
        public void DilateAsExpression()
        {
            var figure = new Expression("(-1,2)(-2,1)(-1,-1)").Dilate(4); //TODO update Dilate
            Assert.AreEqual(figure, "(-4,8)(-8,4)(-4,-4)");
        }

        [DataTestMethod]
        public void CompositeTransformation()
        {
            //var figure = new Cartesian2DPoints(new List<Point>{new Point(-1,-8)});
            var figure = new Cartesian2DPoints("(-1,8)");
            Cartesian2DPoints transformedFigure = figure.Reflect(LineType.Y_axis);  //(1,8)
            transformedFigure = transformedFigure.Translate("4|6");   //(5,14)
            string result = transformedFigure.ToString();
            Assert.AreEqual(result, "(5,14)");
        }

        [DataTestMethod]
        public void CompositeTransformationConcise()
        {
            var figure = new Expression("(-1,8)").Reflect(LineType.Y_axis).Translate("4|6");
            Assert.AreEqual(figure, "(5,14)");
        }

        [DataTestMethod]
        public void CompositeTransformationTriangle()
        {
            var figure = new Cartesian2DPoints("(-3.5,4)(-7,-3)(0,-3)");
            figure = figure.Translate("7|3");
            figure = figure.Reflect(LineType.X_axis);

            var expected = new Cartesian2DPoints("(3.5,-7)(0,0)(7,0)");
            var areEqual = figure.Equals(expected);
            Assert.IsTrue(areEqual);
        }

        [DataTestMethod]
        public void CompositeTransformationTriangleAsExpressionsAgainstCartesion2D() //TODO evaluate/Create Triangle property
        {
            var figure = new Expression("(-3.5,4)(-7,-3)(0,-3)").Translate("7|3").Reflect(LineType.X_axis);
            var expected = new Cartesian2DPoints("(3.5,-7)(0,0)(7,0)");
            Assert.AreEqual(figure, expected);
        }

        [DataTestMethod]
        public void FindYInterceptFromSlopeAndPoint()
        {
            var line = new Line("(3,4)");
            line.M = new Variable(2, "m");
            var test = line.IsValidLine;
            line.FindYIntercept();
            var result = -2 == line?.B?.Expression?.AsNumber?.Data?.AsInt;
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        public void FindYInterceptFromTwoPoints()
        {
            var line = new Line("(1,2)(3,-4)");
            var test = line.IsValidLine;
            line.FindYIntercept();
            var result = 5 == line?.B?.Expression?.AsNumber?.Data?.AsInt;
            Assert.IsTrue(result);
        }
    }
}
