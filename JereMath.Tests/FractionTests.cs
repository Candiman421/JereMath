
using JereMath.Library.JereMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JereMath.Tests
{
    [TestClass]
    public class ExpressionTests
    {

        [TestMethod]
        public void Expression_BuildByString_IntegerValues()
        {
            var actual = new Expression("3/7");
            var expected = new JereNumber(3, 7);
            Assert.AreEqual(actual, expected);

            actual = new Expression("3/7");
            expected = new JereNumber(3, 7);
            Assert.AreEqual(actual, expected);

            actual = new Expression("-3/7");
            expected = new JereNumber(-3, 7);
            Assert.AreEqual(actual, expected);

            actual = new Expression("3/-7");
            expected = new JereNumber(3, -7);
            Assert.AreEqual(actual, expected);

            actual = new Expression("-3/-7");
            expected = new JereNumber(-3, -7);
            Assert.AreEqual(actual, expected);

            actual = new Expression("2(3/7)");
            expected = new JereNumber(17, 7);
            Assert.AreEqual(actual, expected);

            actual = new Expression("-2(3/7)");
            expected = new JereNumber(-17, 7);
            Assert.AreEqual(actual, expected);

            actual = new Expression("2 3/7");
            expected = new JereNumber(17, 7);
            Assert.AreEqual(actual, expected);

            actual = new Expression("-2 3/7");
            expected = new JereNumber(-17, 7);
            Assert.AreEqual(actual, expected);

            try
            {
                actual = new Expression("-2(-3/7)");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Invalid Format"));
            }

            try
            {
                actual = new Expression("-2 -3/7");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Invalid Format"));
            }
        }

        [TestMethod]
        public void Expression_BuildByString_DecimalValues()
        {
            Expression actual = new Expression("2.8/.7");
            Assert.AreEqual(actual, "4");

            actual = new Expression("-2.8/.7");
            Assert.AreEqual(actual, "-4");

            actual = new Expression("2.8/-.7");
            Assert.AreEqual(actual, "-4");

            actual = new Expression("-2.8/-.7");
            Assert.AreEqual(actual, "4");

            actual = new Expression("2.5(3/.5555)");
            var expected = new JereNumber(4.38875, 0.5555);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Expression_BuildByMixedNumberString()
        {
            var first = new Expression("2(3/6)");
            var expected = new JereNumber(15, 6);
            var result = first.Equals(expected);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Expression_Equals_Keyword()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(1, 2);
            var result = first.Equals(second);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Expression_Equals_Operator()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(1, 3);
            var result = first == second;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Expression_NotEquals_Keyword()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(1, 2);
            var result = !first.Equals(second);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void JereNumber_NotEquals_Operator()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(1, 3);
            Assert.IsTrue(first != second);
        }

        [TestMethod]
        public void JereNumber_LesserThanOperator_True()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(4, 6);
            var result = first < second;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void JereNumber_LesserThanOperator_False()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(4, 6);
            var result = second < first;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void JereNumber_LesserThanOperator_IsEqual_ShouldResultFalse()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(3, 6);
            var result = second < first;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void JereNumber_LesserThanOperator_IsGreater_ShouldResultFalse()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(5, 6);
            var result = second < first;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void JereNumber_LesserThanOrEqualToOperator_IsLesser_ShouldResultTrue()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(4, 6);
            var result = first <= second;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void JereNumber_LesserThanOrEqualToOperator_IsEqual_ShouldResultTrue()
        {
            var first = new JereNumber(12, 18);
            var second = new JereNumber(4, 6);
            var result = first <= second;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void JereNumber_LesserThanOrEqualToOperator_IsGreater_ShouldResultFalse()
        {
            var first = new JereNumber(17, 18);
            var second = new JereNumber(4, 6);
            var result = first <= second;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void JereNumber_GreaterThanOperator_True()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(4, 6);
            var result = second > first;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void JereNumber_GreaterThanOperator_False()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(4, 6);
            var result = first > second;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void JereNumber_GreaterThanOperator_IsEqual_ShouldResultFalse()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(3, 6);
            var result = first > second;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void JereNumber_GreaterThanOperator_IsGreater_ShouldResultFalse()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(5, 6);
            var result = first > second;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void JereNumber_GreaterThanOrEqualToOperator_IsGreater_ShouldResultTrue()
        {
            var first = new JereNumber(3, 6);
            var second = new JereNumber(4, 6);
            var result = second >= first;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void JereNumber_GreaterThanOrEqualToOperator_IsEqual_ShouldResultTrue()
        {
            var first = new JereNumber(12, 18);
            var second = new JereNumber(4, 6);
            var result = first >= second;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void JereNumber_GreaterThanOrEqualToOperator_IsLesser_ShouldResultFalse()
        {
            var first = new JereNumber(17, 18);
            var second = new JereNumber(4, 6);
            var result = second >= first;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void JereNumber_ZeroNumerator_IsTrue()
        {
            var first = new JereNumber(0, 7);

            var result = (bool)first.Data?.IsZero;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void JereNumber_ZeroNumerator_PlusOtherEqualsCorrectDenominator()
        {
            var first = new JereNumber(0, 7);
            var second = new JereNumber(3, 5);
            var result = first + second;
            Assert.AreEqual(result, second);
        }

        [TestMethod]
        public void JereNumber_ZeroDenominator_IsUndefined()
        {
            var first = new JereNumber(5, 0);

            var result = first.IsUndefined;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void JereNumber_MixedNumber_18_7()
        {
            var first = new JereNumber(18, 7);
            var result = first.Data.AsMixedNumber;

            Assert.AreEqual("2 4/7", result);
        }

        [TestMethod]
        public void JereNumber_MixedNumber_7_18()
        {
            var first = new JereNumber(7, 18);
            var result = first.Data.AsMixedNumber;

            Assert.AreEqual("7/18", result);
        }

        [TestMethod]
        public void JereNumber_MixedNumber_36_18()
        {
            var first = new JereNumber(36, 18);
            var result = first.Data.AsMixedNumber;

            Assert.AreEqual("2", result.ToString());
        }

        //[TestMethod]
        //public void JereNumber_PlusPlusOperator()
        //{
        //    var first = new JereNumber(1, 7);
        //    first++;
        //    first++;
        //    var second = new JereNumber(3, 7);
        //    Assert.AreEqual(first, second);
        //}

        //[TestMethod]
        //public void JereNumber_MinusMinusOperator()
        //{
        //    var first = new JereNumber(1, 7);
        //    first--;
        //    first--;
        //    var second = new JereNumber(-1, 7);
        //    Assert.AreEqual(first, second);
        //}

        [TestMethod]
        public void JereNumber_Plus_AreEqual()
        {
            var first = new JereNumber(1, 6);
            var second = new JereNumber(2, 6);
            var expected = new JereNumber(9, 18);
            var result = first + second;
            Assert.AreEqual(result, expected);
        }


        [TestMethod]
        public void JereNumber_Plus_areNotEqual()
        {
            var first = new JereNumber(1, 7);
            var second = new JereNumber(2, 6);
            var expected = new JereNumber(9, 18);
            var result = first + second;
            Assert.AreNotEqual(result, expected);
        }

        [TestMethod]
        public void JereNumber_Plus_WithNegativeInDenominator()
        {
            var first = new JereNumber(1, -6);
            var second = new JereNumber(1, 1);
            var expected = new JereNumber(5, 6);
            var result = first + second;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void JereNumber_MinusAgainstSelf_IsNegative()
        {
            var first = new JereNumber(1, 6);
            var result = -first;
            var second = new JereNumber(-1, 6);

            Assert.AreEqual(result, second);
        }

        [TestMethod]
        public void JereNumber_MinusAgainstSelf_StartingWithANegativeDenominator()
        {
            var first = new JereNumber(1, -6);
            var result = -first;
            var second = new JereNumber(1, 6);

            Assert.AreEqual(result, second);
        }

        [TestMethod]
        public void JereNumber_Minus_AreEqual()
        {
            var first = new JereNumber(1, 6);
            var second = new JereNumber(2, 6);
            var expected = new JereNumber(-1, 6);
            var result = first - second;
            Assert.AreEqual(result, expected);
        }


        [TestMethod]
        public void JereNumber_Minus_areNotEqual()
        {
            var first = new JereNumber(1, 6);
            var second = new JereNumber(2, 6);
            var expected = new JereNumber(1, 6);
            var result = first - second;
            Assert.AreNotEqual(result, expected);
        }

        [TestMethod]
        public void JereNumber_Multiply_expectPass()
        {
            var first = new JereNumber(1, 6);
            var second = new JereNumber(1, 6);
            var expected = new JereNumber(1, 36);
            var result = first * second;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void JereNumber_Multiply_expectNotPass()
        {
            var first = new JereNumber(1, 6);
            var second = new JereNumber(-1, 6);
            var expected = new JereNumber(1, 3);
            var result = first * second;
            Assert.AreNotEqual(result, expected);
        }

        [TestMethod]
        public void JereNumber_Multiply_WithZeroNumerator()
        {
            var first = new JereNumber(0, 6);
            var second = new JereNumber(1, 6);
            var result = first * second;
            Assert.IsTrue((bool)result.Data?.IsZero);
            Assert.IsFalse(result.IsUndefined);
        }

        [TestMethod]
        public void JereNumber_Multiply_WithZeroDenominator()
        {
            var first = new JereNumber(6, 0);
            var second = new JereNumber(-1, 6);
            var result = first * second;
            Assert.IsNull(result);
        }

        [TestMethod]
        public void JereNumber_Divide_expectPass()
        {
            var first = new JereNumber(1, 6);
            var second = new JereNumber(14, 32);
            var expected = new JereNumber(8, 21);
            var result = first / second;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void JereNumber_Divide_expectNotPass()
        {
            var first = new JereNumber(1, 6);
            var second = new JereNumber(14, -32);
            var expected = new JereNumber(8, 21);
            var result = first / second;
            Assert.AreNotEqual(result, expected);
        }

        [TestMethod]
        public void JereNumber_Divide_WithZeroNumerator()
        {
            var first = new JereNumber(0, 6);
            var second = new JereNumber(1, 6);
            var result = first / second;
            Assert.IsTrue((bool)result.Data?.IsZero);
            Assert.AreEqual(result, 0);                      //TODO, how to flip these two arguments and not break?
            Assert.IsFalse(result.IsUndefined);
        }

        [TestMethod]
        public void JereNumber_Divide_WithZeroDenominator()
        {
            var first = new JereNumber(6, 0);
            var second = new JereNumber(-1, 6);
            var result = first / second;
            Assert.IsNull(result);
        }

        [TestMethod]
        public void JereNumber_ToDecimal()
        {
            var first = new JereNumber(4, 5);
            var result = first;
            var expected = 0.8;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void JereNumber_ToDecimal_TopHeavy()
        {
            var first = new JereNumber(7, 5);
            var result = first;
            var expected = 1.4;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void JereNumber_ToDecimal_ZeroNumerator()
        {
            var first = new JereNumber(0, 5);
            var result = first;
            var expected = 0;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void JereNumber_ToDecimal_ZeroDenominator()
        {
            var first = new JereNumber(5, 0);
            var result = first;
            Assert.IsTrue(result.IsUndefined);
        }
    }
}