using JereMath.Library.JereMath.Enums;
using JereMath.Library.JereMath.Extensions;
using JereMath.Library.JereMath.RegexUtil;
using System;
using System.Collections.Generic;
using System.Text;
using static JereMath.Library.JereMath.Extensions.DecimalExtensions;

namespace JereMath.Library.JereMath
{
    public class JereNumber : IEquatable<JereNumber>
    {
        public string Representation => Data?.DefaultRepresentation ?? "undefined";
        public string OriginalRepresentation { get; set; }

        public bool IsUndefined { get; set; }
        public decimal OriginalNumerator { get; set; }
        public decimal OriginalDenominator { get; set; }

        private decimal? _numerator { get; set; }
        private decimal? _denominator { get; set; }
        private bool? _isNegative => Data?.IsNegative;
        private bool? _isZero => Data?.IsZero;

        public Metadata Data { get; set; }

        public JereNumber(string givenText)
        {
            OriginalRepresentation = $"{givenText}";
            try
            {
                if (givenText == "undefined")
                {
                    OriginalNumerator = 1;
                    OriginalDenominator = 0;
                }
                else if (RegexPatterns.MixedNumberOrFractionOrNumber.IsMatch(givenText))
                {
                    var namedCaptures = RegexPatterns.MixedNumberOrFractionOrNumber.MatchNamedCaptures(givenText);

                    if (!string.IsNullOrEmpty(namedCaptures[RegexCaptureName.entireNumber.Name()].ToString()))
                    {
                        decimal.TryParse(namedCaptures[RegexCaptureName.entireNumber.Name()].ToString(), out decimal number);

                        OriginalNumerator = number;
                        OriginalDenominator = 1;
                    }
                    else
                    {
                        decimal.TryParse(namedCaptures[RegexCaptureName.entireMixedNumbersNumber.Name()].ToString(), out decimal number);
                        decimal.TryParse(namedCaptures[RegexCaptureName.entireNumerator.Name()].ToString(), out decimal numerator);
                        decimal.TryParse(namedCaptures[RegexCaptureName.entireDenominator.Name()].ToString(), out decimal denominator);

                        if (number != 0)
                        {
                            if (numerator.IsNegative() || denominator.IsNegative()) //TODO debatable as to enable this
                            {
                                throw new ArgumentException("Invalid Format:\nValid Samples:\n2(3/5)\n-2 3/5\n3/5\n-3/5\n3/-5");
                            }

                            var absoluteValue = Math.Abs(number) * denominator + numerator;
                            OriginalNumerator = number.IsNegative() ? -absoluteValue : absoluteValue;
                            OriginalDenominator = denominator;
                        }
                        else
                        {
                            OriginalNumerator = numerator;
                            OriginalDenominator = denominator;
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid Format:\nValid Samples:\n2(3/5)\n-2 3/5\n3/5\n-3/5\n3/-5");
                }
                PopulateValues();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JereNumber(int number)
        {
            OriginalRepresentation = $"{number}";
            OriginalNumerator = number;
            OriginalDenominator = 1;
            PopulateValues();
        }
        public JereNumber(long number)
        {
            OriginalRepresentation = $"{number}";
            OriginalNumerator = number;
            OriginalDenominator = 1;
            PopulateValues();
        }
        public JereNumber(double number)
        {
            OriginalRepresentation = $"{number}";
            OriginalNumerator = (decimal)number;
            OriginalDenominator = 1;
            PopulateValues();
        }
        public JereNumber(decimal number)
        {
            OriginalRepresentation = $"{number}";
            OriginalNumerator = number;
            OriginalDenominator = 1;
            PopulateValues();
        }

        public JereNumber(int numerator, int denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = numerator;
            OriginalDenominator = denominator;
            PopulateValues();
        }
        public JereNumber(int numerator, long denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = numerator;
            OriginalDenominator = denominator;
            PopulateValues();
        }
        public JereNumber(int numerator, double denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = numerator;
            OriginalDenominator = (decimal)denominator;
            PopulateValues();
        }
        public JereNumber(int numerator, decimal denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = numerator;
            OriginalDenominator = denominator;
            PopulateValues();
        }

        public JereNumber(long numerator, int denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = numerator;
            OriginalDenominator = denominator;
            PopulateValues();
        }
        public JereNumber(long numerator, long denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = numerator;
            OriginalDenominator = denominator;
            PopulateValues();
        }
        public JereNumber(long numerator, double denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = numerator;
            OriginalDenominator = (decimal)denominator;
            PopulateValues();
        }
        public JereNumber(long numerator, decimal denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = numerator;
            OriginalDenominator = denominator;
            PopulateValues();
        }

        public JereNumber(double numerator, int denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = (decimal)numerator;
            OriginalDenominator = denominator;
            PopulateValues();
        }
        public JereNumber(double numerator, long denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = (decimal)numerator;
            OriginalDenominator = denominator;
            PopulateValues();
        }
        public JereNumber(double numerator, double denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = (decimal)numerator;
            OriginalDenominator = (decimal)denominator;
            PopulateValues();
        }
        public JereNumber(double numerator, decimal denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = (decimal)numerator;
            OriginalDenominator = denominator;
            PopulateValues();
        }

        public JereNumber(decimal numerator, int denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = numerator;
            OriginalDenominator = denominator;
            PopulateValues();
        }
        public JereNumber(decimal numerator, long denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = numerator;
            OriginalDenominator = denominator;
            PopulateValues();
        }
        public JereNumber(decimal numerator, double denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = numerator;
            OriginalDenominator = (decimal)denominator;
            PopulateValues();
        }
        public JereNumber(decimal numerator, decimal denominator)
        {
            OriginalRepresentation = $"{numerator}/{denominator}";
            OriginalNumerator = numerator;
            OriginalDenominator = denominator;
            PopulateValues();
        }

        public static JereNumber operator -(JereNumber right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (operator -)");
            if (right.IsUndefined) return null;

            var result = new JereNumber((decimal)-right._numerator, (decimal)right._denominator);
            return result;
        }
        public static JereNumber operator -(JereNumber left, JereNumber right)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (operator -)");
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (operator -)");
            if (left.IsUndefined || right.IsUndefined) return null;

            JereNumber result;

            if ((bool)left._isZero)
            {
                result = -right;
            }
            else if ((bool)right._isZero)
            {
                result = left;
            }
            else if (left._denominator == right._denominator)
            {
                decimal top = (decimal)left._numerator - (decimal)right._numerator;
                decimal bottom = (decimal)left._denominator;
                result = new JereNumber(top, bottom);
            }
            else
            {
                decimal top = (decimal)left._numerator * (decimal)right._denominator - (decimal)left._denominator * (decimal)right._numerator;
                decimal bottom = (decimal)left._denominator * (decimal)right._denominator;
                result = new JereNumber(top, bottom);
            }

            return result;
        }
        public static JereNumber operator +(JereNumber left, JereNumber right)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (operator +)");
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (operator +)");
            if (left.IsUndefined || right.IsUndefined) return null;

            JereNumber result;

            if ((bool)left._isZero)
            {
                result = right;
            }
            else if ((bool)right._isZero)
            {
                result = left;
            }
            else if (left._denominator == right._denominator)
            {
                var top = left._numerator + right._numerator;
                var bottom = left._denominator;
                result = new JereNumber((decimal)top, (decimal)bottom);
            }
            else
            {
                var top = left._numerator * right._denominator + left._denominator * right._numerator;
                var bottom = left._denominator * right._denominator;
                result = new JereNumber((decimal)top, (decimal)bottom);
            }

            return result;
        }
        public static JereNumber operator *(JereNumber left, JereNumber right)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (operator *)");
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (operator *)");
            if (left.IsUndefined || right.IsUndefined) return null;

            decimal numerator = (decimal)left._numerator * (decimal)right._numerator;
            decimal denominator = (decimal)left._denominator * (decimal)right._denominator;
            return new JereNumber(numerator, denominator);
        }
        public static JereNumber operator /(JereNumber left, JereNumber right)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (operator /)");
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (operator /)");
            if (left.IsUndefined || right.IsUndefined) return null;
            if ((bool)right._isZero) return null;
            if ((bool)left._isZero && !(bool)right._isZero) return 0;

            var numerator = left._numerator * right._denominator;
            var denominator = left._denominator * right._numerator;
            return new JereNumber((decimal)numerator, (decimal)denominator);
        }

        public static bool operator ==(JereNumber left, JereNumber right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) { throw new ArgumentNullException("left and right are both null: (operator ==)"); } //or should both as null be equal?}
            if (ReferenceEquals(left, null)) return false;
            if (ReferenceEquals(right, null)) return false;
            if (left.IsUndefined) throw new ArithmeticException("left undefined: (operator ==)");
            if (right.IsUndefined) throw new ArithmeticException("right undefined: (operator ==)");

            return left.Representation == right.Representation;
        }
        public static bool operator !=(JereNumber left, JereNumber right)
        {
            return !(left == right);
        }
        public static bool operator <(JereNumber left, JereNumber right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) { throw new ArgumentNullException("left and right are both null: (operator ==)"); } //or should both as null be equal?}
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (operator <)");
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (operator <)");
            if (left.IsUndefined) throw new ArithmeticException("left undefined: (operator <)");
            if (right.IsUndefined) throw new ArithmeticException("right undefined: (operator <)");

            decimal? leftTemp = left._numerator * right._denominator;
            decimal? rightTemp = right._numerator * left._denominator;
            return leftTemp < rightTemp;
        }
        public static bool operator >(JereNumber left, JereNumber right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) { throw new ArgumentNullException("left and right are both null: (operator ==)"); } //or should both as null be equal?}
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (operator >)");
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (operator >)");
            if (left.IsUndefined) throw new ArithmeticException("left undefined: (operator >)");
            if (right.IsUndefined) throw new ArithmeticException("right undefined: (operator >)");

            decimal? leftTemp = left._numerator * right._denominator;
            decimal? rightTemp = right._numerator * left._denominator;
            return leftTemp > rightTemp;
        }
        public static bool operator <=(JereNumber left, JereNumber right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) { throw new ArgumentNullException("left and right are both null: (operator ==)"); } //or should both as null be equal?}
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (operator <=)");
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (operator <=)");
            if (left.IsUndefined) throw new ArithmeticException("left undefined: (operator <=)");
            if (right.IsUndefined) throw new ArithmeticException("right undefined: (operator <=)");

            decimal? leftTemp = left._numerator * right._denominator;
            decimal? rightTemp = right._numerator * left._denominator;
            return leftTemp <= rightTemp;
        }
        public static bool operator >=(JereNumber left, JereNumber right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) { throw new ArgumentNullException("left and right are both null: (operator ==)"); } //or should both as null be equal?}
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (operator >=)");
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right: (operator >=)");
            if (left.IsUndefined) throw new ArithmeticException("left undefined: (operator >=)");
            if (right.IsUndefined) throw new ArithmeticException("right undefined: (operator >=)");

            decimal? leftTemp = left._numerator * right._denominator;
            decimal? rightTemp = right._numerator * left._denominator;
            return leftTemp >= rightTemp;
        }

        public static implicit operator JereNumber(string left)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (implicit string to Number)");

            return new JereNumber(left);
        }
        public static implicit operator JereNumber(decimal left)
        {
            return new JereNumber(left);
        }

        public static implicit operator string(JereNumber left)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (implicit Number to Representation)");
            if (left.IsUndefined) throw new ArithmeticException("undefined: (implicit Number to Representation)");

            return left.Representation;
        }
        public static implicit operator int(JereNumber left)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (implicit Number to AsInt)");
            if (left.IsUndefined) throw new ArithmeticException("undefined: (implicit Number to AsInt)");

            return left.Data.AsInt;
        }
        public static implicit operator int?(JereNumber left)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (implicit Number to AsIntNoLoss)");
            if (left.IsUndefined) throw new ArithmeticException("undefined: (implicit Number to AsIntNoLoss)");

            return left.Data.AsIntNoLoss;
        }
        public static implicit operator long(JereNumber left)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (implicit Number to AsLong)");
            if (left.IsUndefined) throw new ArithmeticException("undefined: (implicit Number to AsLong)");

            return left.Data.AsLong;
        }
        public static implicit operator long?(JereNumber left)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (implicit Number to AsLongNoLoss)");
            if (left.IsUndefined) throw new ArithmeticException("undefined: (implicit Number to AsLongNoLoss)");

            return left.Data.AsLongNoLoss;
        }
        public static implicit operator double(JereNumber left)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (implicit Number to AsDouble)");
            if (left.IsUndefined) throw new ArithmeticException("undefined: (implicit Number to AsDouble)");

            return left.Data.AsDouble;
        }
        public static implicit operator double?(JereNumber left)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (implicit Number to AsDoubleNoLoss)");
            if (left.IsUndefined) throw new ArithmeticException("undefined: (implicit Number to AsDoubleNoLoss)");

            return left.Data.AsDoubleNoLoss;
        }
        public static implicit operator decimal(JereNumber left)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (implicit Number to AsDecimal)");
            if (left.IsUndefined) throw new ArithmeticException("undefined: (implicit Number to AsDecimal)");

            return left.Data.AsDecimal;
        }
        public static implicit operator decimal?(JereNumber left)
        {
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left: (implicit Number to AsDecimalNoLoss)");
            if (left.IsUndefined) throw new ArithmeticException("undefined: (implicit Number to AsDecimalNoLoss)");

            return left.Data.AsDecimalNoLoss;
        }

        bool IEquatable<JereNumber>.Equals(JereNumber right)
        {
            return this == right;
        }
        public override bool Equals(object obj)
        {
            if (decimal.TryParse(obj.ToString(), out decimal asDecimal))
            {
                return Data.AsDecimal == asDecimal;
            }
            else
            {
                return Representation == obj.ToString();
            }
        }
        public override int GetHashCode()
        {
            int hashCode = -1534900553;
            hashCode = hashCode * -1521134295 + Representation.GetHashCode();
            return hashCode;
        }

        public void PopulateValues()
        {
            IsUndefined = OriginalDenominator == 0;
            if (IsUndefined) return;

            Simplify();
            Data = new Metadata(this);
        }

        public void Simplify()
        {
            decimal tempNumerator;
            decimal tempDenominator;

            //Normalize Negatives
            if (OriginalDenominator < 0)
            {
                tempNumerator = -OriginalNumerator;
                tempDenominator = -OriginalDenominator;
            }
            else
            {
                tempNumerator = OriginalNumerator;
                tempDenominator = OriginalDenominator;
            }

            if (tempNumerator == 0 && tempDenominator != 0) //isZero
            {
                _numerator = tempNumerator;
                _denominator = tempDenominator;
            }
            else
            {
                //Simplify Numbers
                decimal divisor = MathHelper.GreatestCommonDivisor(tempNumerator, tempDenominator);
                _numerator = tempNumerator / divisor;
                _denominator = tempDenominator / divisor;
            }
        }
        public override string ToString()
        {
            return Representation;
        }

        public class Metadata
        {
            public string DefaultRepresentation { get; set; }

            public bool IsUndefined = false; //must follow this rule for Metadata to exist
            public bool IsNegative { get; set; }
            public bool IsZero { get; set; }

            public int AsInt { get; set; } // regardless of loss
            public bool AsIntIsNoLoss { get; set; }
            public int? AsIntNoLoss { get; set; }  // only if no loss

            public long AsLong { get; set; }
            public bool AsLongIsNoLoss { get; set; }
            public long? AsLongNoLoss { get; set; }

            public double AsDouble { get; set; }
            public bool AsDoubleIsNoLoss { get; set; }
            public double? AsDoubleNoLoss { get; set; }

            public decimal AsDecimal { get; set; }
            public bool AsDecimalIsNoLoss { get; set; }
            public decimal? AsDecimalNoLoss { get; set; }

            public string AsOriginalFraction { get; set; }
            public string AsFraction { get; set; }   // regardless of loss
            public bool AsFractionIsNoLoss { get; set; }
            public string AsFractionNoLoss { get; set; }  // only if no loss

            public string AsMixedNumber { get; set; }  // regardless of loss
            public bool AsMixedNumberIsNoLoss { get; set; }
            public string AsMixedNumberNoLoss { get; set; }  // only if no loss

            public decimal? SimplifiedNumerator { get; set; }
            public decimal? SimplifiedDenominator { get; set; }
            public string SimplifiedAsFraction { get; set; }

            public decimal OriginalNumerator { get; set; }
            public decimal OriginalDenominator { get; set; }
            public string OriginalAsFraction { get; set; }


            public Metadata(JereNumber number)
            {
                ProcessDecimal(number);
                PopulateRepresentations(number);
            }

            private bool ProcessFraction(JereNumber number)
            {
                //IsNegative = number._denominator == 0 || _numerator == 0 ? false : _numerator * number._denominator < 0;
                //IsZero = number._numerator == 0 && number._denominator != 0;

                //OriginalNumerator = number.OriginalNumerator;
                //OriginalDenominator = number.OriginalDenominator;
                //AsOriginalFraction = $"{OriginalNumerator}/{OriginalDenominator}";

                //SimplifiedNumerator = number._numerator;
                //SimplifiedDenominator = number._denominator;
                //SimplifiedAsFraction = $"{SimplifiedNumerator}/{SimplifiedDenominator}";

                return true;
            }
            private void ProcessDecimal(JereNumber number)
            {
                AsDecimal = (decimal)number._numerator / (decimal)number._denominator;
                //if longer than 28 decimal places = approximate, not rational
                //if has repeating decimal pattern, and longer than 28 decimal places = approximate, rational
                //https://stackoverflow.com/questions/1315595/algorithm-for-detecting-repeating-decimals
                //http://mathworld.wolfram.com/DecimalExpansion.html
                //https://softwareengineering.stackexchange.com/questions/192070/what-is-a-efficient-way-to-find-repeating-decimal
                //https://www.exceptionnotfound.net/decimal-vs-double-and-other-tips-about-number-types-in-net/
                //https://fiziko.bureau42.com/teaching_tidbits/turning_repeating_decimals_into_fractions.pdf
                //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
                //https://docs.microsoft.com/en-us/dotnet/api/system.decimal.compareto?view=netframework-4.8#System_Decimal_CompareTo_System_Decimal_
                //.compareTo() and equals()
                //a decimal may have precision of 28-29, does that include left and right? yes
                //Precision is 28-29, scale is # of digits after decimal point
                //Use brute force method for now
                if (AsDecimal.SignificantDigits() < 28) //No loss
                {
                    AsDecimalIsNoLoss = true;
                    AsDecimalNoLoss = AsDecimal;
                    ProcessDecimalNoLoss((decimal)AsDecimalNoLoss);
                }
                else //All lesser types will be approximate too.
                {
                    AsInt = (int)(number._numerator / number._denominator);
                    AsLong = (long)(number._numerator / number._denominator);
                    AsDouble = (double)(number._numerator / number._denominator);
                }
            }
            private void ProcessDecimalNoLoss(decimal number)
            {
                AsInt = (int)number;
                AsIntIsNoLoss = AsInt == number;
                AsIntNoLoss = AsIntIsNoLoss ? AsInt : (int?)null;

                AsLong = (long)number;
                AsLongIsNoLoss = AsLong == number;
                AsLongNoLoss = AsLongIsNoLoss ? AsLong : (long?)null;

                AsDouble = (double)number;
                AsDoubleIsNoLoss = (decimal)AsDouble == number;
                AsDoubleNoLoss = AsDoubleIsNoLoss ? AsDouble : (double?)null;
            }

            private void CalculateFractionRepresentations(JereNumber number)
            {
                IsNegative = number._denominator == 0 || number._numerator == 0 ? false : number._numerator * number._denominator < 0;
                IsZero = number._numerator == 0 && number._denominator != 0;

                OriginalNumerator = number.OriginalNumerator;
                OriginalDenominator = number.OriginalDenominator;
                AsOriginalFraction = $"{OriginalNumerator}/{OriginalDenominator}";

                SimplifiedNumerator = number._numerator;
                SimplifiedDenominator = number._denominator;

                //undefined already taken care of
                if (IsZero)
                {
                    AsFraction = $"{SimplifiedNumerator}/{SimplifiedDenominator}";
                    AsFractionIsNoLoss = true;
                    AsFractionNoLoss = $"{SimplifiedNumerator}/{SimplifiedDenominator}";
                }
                else
                {
                    AsFraction = $"{SimplifiedNumerator}/{SimplifiedDenominator}";
                    if (SimplifiedNumerator.SignificantDigits() < 28
                     && SimplifiedDenominator.SignificantDigits() < 28)
                    {
                        AsFractionIsNoLoss = true;
                        AsFractionNoLoss = $"{SimplifiedNumerator}/{SimplifiedDenominator}";
                    }
                }
            }
            private void CalculateMixedNumberRepresentations()
            {
                decimal mixedNumberNumerator;
                decimal mixedNumberDenominator;
                decimal number;
                if (Math.Abs((decimal)SimplifiedNumerator) == Math.Abs((decimal)SimplifiedDenominator))
                {
                    number = (decimal)SimplifiedNumerator / (decimal)SimplifiedDenominator;
                    AsMixedNumber = $"{number}";
                    if (number.SignificantDigits() < 28) //No loss
                    {
                        AsMixedNumberIsNoLoss = true;
                        AsMixedNumberNoLoss = $"{number}";
                    }
                }
                else if (Math.Abs((decimal)SimplifiedNumerator) > Math.Abs((decimal)SimplifiedDenominator)) //if top heavy
                {
                    decimal numberTemp = Math.Floor(Math.Abs((decimal)SimplifiedNumerator) / Math.Abs((decimal)SimplifiedDenominator));
                    decimal remainder = Math.Abs((decimal)SimplifiedNumerator) % Math.Abs((decimal)SimplifiedDenominator);
                    number = IsNegative ? -numberTemp : numberTemp;

                    mixedNumberNumerator = remainder;
                    mixedNumberDenominator = Math.Abs((decimal)SimplifiedDenominator);

                    if (mixedNumberDenominator == 0)
                    {
                        AsMixedNumber = null;
                        AsMixedNumberIsNoLoss = false;
                        AsMixedNumberNoLoss = null;
                    }
                    else if (mixedNumberNumerator == 0)
                    {
                        AsMixedNumber = $"{number}";
                        if (number.SignificantDigits() < 28) //No loss
                        {
                            AsMixedNumberIsNoLoss = true;
                            AsMixedNumberNoLoss = $"{number}";
                        }
                    }
                    else if (number == 0)
                    {
                        //not a real thing
                        throw new Exception("you're a weirdo");
                    }
                    else if (number > 0 || number < 0)
                    {
                        AsMixedNumber = $"{number} {mixedNumberNumerator}/{mixedNumberDenominator}";
                        if (number.SignificantDigits() < 28
                            && mixedNumberNumerator.SignificantDigits() < 28
                            && mixedNumberDenominator.SignificantDigits() < 28)
                        {
                            AsMixedNumberIsNoLoss = true;
                            AsMixedNumberNoLoss = $"{number} {mixedNumberNumerator}/{mixedNumberDenominator}";
                        }
                    }
                    else
                    {
                        throw new Exception("What are you doing here!!!");
                    }
                }
                else //bottom heavy
                {
                    mixedNumberNumerator = Math.Abs((decimal)SimplifiedNumerator);
                    mixedNumberDenominator = Math.Abs((decimal)SimplifiedDenominator);
                    if (IsNegative)
                    {
                        mixedNumberNumerator = -mixedNumberNumerator;
                    }

                    if (mixedNumberDenominator == 0)
                    {
                        AsMixedNumber = "undefined";
                        AsMixedNumberIsNoLoss = false;
                        AsMixedNumberNoLoss = null;
                    }
                    else if (mixedNumberNumerator == 0)
                    {
                        AsMixedNumber = "0";
                        AsMixedNumberIsNoLoss = true;
                        AsMixedNumberNoLoss = "0";
                    }
                    else
                    {
                        AsMixedNumber = $"{mixedNumberNumerator}/{mixedNumberDenominator}";
                        if (mixedNumberNumerator.SignificantDigits() < 28
                            && mixedNumberDenominator.SignificantDigits() < 28)
                        {
                            AsMixedNumberIsNoLoss = true;
                            AsMixedNumberNoLoss = $"{mixedNumberNumerator}/{mixedNumberDenominator}";
                        }
                    }
                }
            }
            private void PopulateRepresentations(JereNumber number)
            {
                SimplifiedAsFraction = $"{SimplifiedNumerator}/{SimplifiedDenominator}";
                OriginalAsFraction = $"{OriginalNumerator}/{OriginalDenominator}";
                CalculateFractionRepresentations(number);
                CalculateMixedNumberRepresentations();

                if (IsZero) DefaultRepresentation = "0";
                else if (AsIntNoLoss.HasValue) DefaultRepresentation = AsIntNoLoss.ToString();
                else if (AsLongNoLoss.HasValue) DefaultRepresentation = AsLongNoLoss.ToString();
                else if (AsDoubleNoLoss.HasValue) DefaultRepresentation = AsDoubleNoLoss.ToString();
                else if (AsDecimalNoLoss.HasValue) DefaultRepresentation = AsDecimalNoLoss.ToString();
                else if (AsMixedNumberNoLoss != null) DefaultRepresentation = AsMixedNumberNoLoss;
                else if (AsFractionNoLoss != null) DefaultRepresentation = AsFractionNoLoss; //would this ever hit?
                else DefaultRepresentation = SimplifiedAsFraction; //last one could be approximation if num or denom over 28 Significants long.
            }
        }
    }
}