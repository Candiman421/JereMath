using System;
using System.Collections.Generic;
using System.Text;

namespace JereMath.Library.JereMath
{
    public static class ExpressionLibrary  //  ⁰  ¹  ²  ³  ⁴  ⁵  ⁶  ⁷  ⁸  ⁹  ⁿ    ₀  ₁  ₂  ₃  ₄  ₅  ₆  ₇  ₈  ₉
    {
        public const string PointSlopeForm = @"y-y₁=m(x-x₁)";
        public const string PointSlopeForm_Reg = @"y-y1=m(x-x1)";
        public const string SlopeFormula = @"m=(y₂-y₁)/(x₂-x₁)";
        public const string SlopeFormula_Reg = @"m=(y2-y1)/(x2-x1)";
        public const string SlopeInterceptForm = @"y=mx+b";
    }
}
