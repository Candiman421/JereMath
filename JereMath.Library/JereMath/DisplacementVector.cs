using JereMath.Library.JereMath.RegexUtil;
using System;
using System.Text;

namespace JereMath.Library.JereMath
{

    public class DisplacementVector //TODO Generify tons of this
    {
        public Expression TopHorizontal => DispVector.Top;
        public Expression BottomVertical => DispVector.Bottom;
        public TopBottom<Expression, Expression> DispVector { get; set; }
        //public string Representation { get; set; }

        public DisplacementVector(string displacementVectorFormat)
        {
            if (RegexPatterns.DisplacementVector.IsMatch(displacementVectorFormat))
            {
                var pairs = displacementVectorFormat.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                var top = new Expression(pairs[0]);
                var bottom = new Expression(pairs[1]);
                DispVector = new TopBottom<Expression, Expression>(top, bottom);
            }
            else
            {
                throw new ArgumentException("Must use proper format");
            }
        }

        public DisplacementVector(Expression horizontal, Expression vertical)
        {
            DispVector = new TopBottom<Expression, Expression>(horizontal, vertical);
        }

        public DisplacementVector(TopBottom<Expression, Expression> value)
        {
            DispVector = value;
        }

        public static implicit operator DisplacementVector(string displacementVectorFormat)
        {
            if (ReferenceEquals(displacementVectorFormat, null)) throw new ArgumentNullException("displacementVectorFormat");

            if (RegexPatterns.DisplacementVector.IsMatch(displacementVectorFormat))
            {
                return new DisplacementVector(displacementVectorFormat);
            }
            else
            {
                throw new ArgumentException("Must use proper format");
            }
        }

        public static explicit operator DisplacementVector(Expression expression)
        {
            if (ReferenceEquals(expression, null)) throw new ArgumentNullException("expression");

            return expression.IsDisplacementVector ? new DisplacementVector(expression.Representation) : null;
        }

        public static implicit operator Expression(DisplacementVector displacementVector)
        {
            if (ReferenceEquals(displacementVector, null)) throw new ArgumentNullException("value");

            return new Expression(displacementVector.ToString());
        }

        public override string ToString()
        { //Expression can only be Jerenumber... I think.
            return $"{TopHorizontal.Representation}|{BottomVertical.Representation}";
        }
    }
}
