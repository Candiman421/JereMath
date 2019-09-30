using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JereMath.Library.JereMath.RegexUtil
{
    public static class RegexPatterns
    {
        public static Regex Number = new Regex(@"^
                                                 (?<entireNumber>
                                                   (?<numberNegative>-|)
                                                   (?<number>\d*\.?\d+)
                                                 )
                                               $", RegexOptions.IgnorePatternWhitespace);

        public static Regex MixedNumberOrFractionOrNumber = new Regex(@"^
                                                                       (?: 
                                                                         (?<entireMixedNumber>                                                                             
                                                                           (?:
                                                                             (?<entireMixedNumbersNumber>
                                                                               (?<mixedNumberNegative>-|)
                                                                               (?<mixedNumber>\d*\.?\d+)
                                                                             )
                                                                             (?:  \(  |  \s+  )
                                                                           )?
                                                                           (?:
                                                                             (?<entireFraction>
                                                                               (?<entireNumerator>
                                                                                 (?<numeratorNegative>-|)
                                                                                 (?<numerator>\d*\.?\d+)
                                                                               )
                                                                               \/
                                                                               (?<entireDenominator>
                                                                                 (?<denominatorNegative>-|)
                                                                                 (?<denominator>\d*\.?\d+)
                                                                               )
                                                                             )
                                                                             (?:  \)  |  \s+  )?
                                                                           )
                                                                         )
                                                                       |
                                                                         (?<entireNumber>
                                                                           (?<numberNegative>-|)
                                                                           (?<number>\d*\.?\d+)
                                                                         )
                                                                       )
                                                                     $", RegexOptions.IgnorePatternWhitespace);

        //public static Regex Point2D = new Regex(@"
        //public static Regex Point3D = new Regex(@"
        //public static Regex Line = new Regex(@"
        //public static Regex Cartesian2DPoints = new Regex(@"
        public static Regex Point2DList = new Regex(@"^
                                                   (?<point2dList>
                                                     \(
                                                        (?<x>
                                                          (?<entireMixedNumberX>                                                                             
                                                            (?:
                                                              (?<entireMixedNumbersNumberX>
                                                                (?<mixedNumberNegativeX>-|)
                                                                (?<mixedNumberX>\d*\.?\d+)
                                                              )
                                                              (?:  \(  |  \s+  )
                                                            )?
                                                            (?:
                                                              (?<entireFractionX>
                                                                (?<entireNumeratorX>
                                                                  (?<numeratorNegativeX>-|)
                                                                  (?<numeratorX>\d*\.?\d+)
                                                                )
                                                                \/
                                                                (?<entireDenominatorX>
                                                                  (?<denominatorNegativeX>-|)
                                                                  (?<denominatorX>\d*\.?\d+)
                                                                )
                                                              )
                                                              (?:  \)  |  \s+  )?
                                                            )
                                                          )
                                                        |
                                                          (?<entireNumberX>
                                                            (?<numberNegativeX>-|)
                                                            (?<numberX>\d*\.?\d+)
                                                          )
                                                        )
                                                      ,
                                                        (?<y>
                                                          (?<entireMixedNumberY>                                                                             
                                                            (?:
                                                              (?<entireMixedNumbersNumberY>
                                                                (?<mixedNumberNegativeY>-|)
                                                                (?<mixedNumberY>\d*\.?\d+)
                                                              )
                                                              (?:  \(  |  \s+  )
                                                            )?
                                                            (?:
                                                              (?<entireFractionY>
                                                                (?<entireNumeratorY>
                                                                  (?<numeratorNegativeY>-|)
                                                                  (?<numeratorY>\d*\.?\d+)
                                                                )
                                                                \/
                                                                (?<entireDenominatorY>
                                                                  (?<denominatorNegativeY>-|)
                                                                  (?<denominatorY>\d*\.?\d+)
                                                                )
                                                              )
                                                              (?:  \)  |  \s+  )?
                                                            )
                                                          )
                                                        |
                                                          (?<entireNumberY>
                                                            (?<numberNegativeY>-|)
                                                            (?<numberY>\d*\.?\d+)
                                                          )
                                                        )
                                                   \)
                                                 )+                                       
                                               $", RegexOptions.IgnorePatternWhitespace);

        public static Regex Point3DList = new Regex(@"^
                                                   (?<point3dList>
                                                     \(
                                                        (?: 
                                                          (?<entireMixedNumberX>                                                                             
                                                            (?:
                                                              (?<entireMixedNumbersNumberX>
                                                                (?<mixedNumberNegativeX>-|)
                                                                (?<mixedNumberX>\d*\.?\d+)
                                                              )
                                                              (?:  \(  |  \s+  )
                                                            )?
                                                            (?:
                                                              (?<entireFractionX>
                                                                (?<entireNumeratorX>
                                                                  (?<numeratorNegativeX>-|)
                                                                  (?<numeratorX>\d*\.?\d+)
                                                                )
                                                                \/
                                                                (?<entireDenominatorX>
                                                                  (?<denominatorNegativeX>-|)
                                                                  (?<denominatorX>\d*\.?\d+)
                                                                )
                                                              )
                                                              (?:  \)  |  \s+  )?
                                                            )
                                                          )
                                                        |
                                                          (?<entireNumberX>
                                                            (?<numberNegativeX>-|)
                                                            (?<numberX>\d*\.?\d+)
                                                          )
                                                        )
                                                      ,
                                                        (?: 
                                                          (?<entireMixedNumberY>                                                                             
                                                            (?:
                                                              (?<entireMixedNumbersNumberY>
                                                                (?<mixedNumberNegativeY>-|)
                                                                (?<mixedNumberY>\d*\.?\d+)
                                                              )
                                                              (?:  \(  |  \s+  )
                                                            )?
                                                            (?:
                                                              (?<entireFractionY>
                                                                (?<entireNumeratorY>
                                                                  (?<numeratorNegativeY>-|)
                                                                  (?<numeratorY>\d*\.?\d+)
                                                                )
                                                                \/
                                                                (?<entireDenominatorY>
                                                                  (?<denominatorNegativeY>-|)
                                                                  (?<denominatorY>\d*\.?\d+)
                                                                )
                                                              )
                                                              (?:  \)  |  \s+  )?
                                                            )
                                                          )
                                                        |
                                                          (?<entireNumberY>
                                                            (?<numberNegativeY>-|)
                                                            (?<numberY>\d*\.?\d+)
                                                          )
                                                        )
                                                     ,
                                                        (?: 
                                                          (?<entireMixedNumberZ>                                                                             
                                                            (?:
                                                              (?<entireMixedNumbersNumberZ>
                                                                (?<mixedNumberNegativeZ>-|)
                                                                (?<mixedNumberZ>\d*\.?\d+)
                                                              )
                                                              (?:  \(  |  \s+  )
                                                            )?
                                                            (?:
                                                              (?<entireFractionZ>
                                                                (?<entireNumeratorZ>
                                                                  (?<numeratorNegativeZ>-|)
                                                                  (?<numeratorZ>\d*\.?\d+)
                                                                )
                                                                \/
                                                                (?<entireDenominatorZ>
                                                                  (?<denominatorNegativeZ>-|)
                                                                  (?<denominatorZ>\d*\.?\d+)
                                                                )
                                                              )
                                                              (?:  \)  |  \s+  )?
                                                            )
                                                          )
                                                        |
                                                          (?<entireNumberZ>
                                                            (?<numberNegativeZ>-|)
                                                            (?<numberZ>\d*\.?\d+)
                                                          )
                                                        )
                                                   \)
                                                 )+                                       
                                               $", RegexOptions.IgnorePatternWhitespace);

        public static Regex DisplacementVector = new Regex(@"^
                                                             (?<displacementVector>
                                                               (?<horizontalTop> 
                                                                 (?<entireMixedNumberX>                                                                             
                                                                   (?:
                                                                     (?<entireMixedNumbersNumberX>
                                                                       (?<mixedNumberNegativeX>-|)
                                                                       (?<mixedNumberX>\d*\.?\d+)
                                                                     )
                                                                     (?:  \(  |  \s+  )
                                                                   )?
                                                                   (?:
                                                                     (?<entireFractionX>
                                                                       (?<entireNumeratorX>
                                                                         (?<numeratorNegativeX>-|)
                                                                         (?<numeratorX>\d*\.?\d+)
                                                                       )
                                                                       \/
                                                                       (?<entireDenominatorX>
                                                                         (?<denominatorNegativeX>-|)
                                                                         (?<denominatorX>\d*\.?\d+)
                                                                       )
                                                                     )
                                                                     (?:  \)  |  \s+  )?
                                                                   )
                                                                 )
                                                               |
                                                                 (?<entireNumberX>
                                                                   (?<numberNegativeX>-|)
                                                                   (?<numberX>\d*\.?\d+)
                                                                 )
                                                               )
                                                             \|
                                                               (?<verticalBottom>
                                                                 (?<entireMixedNumberY>                                                                             
                                                                   (?:
                                                                     (?<entireMixedNumbersNumberY>
                                                                       (?<mixedNumberNegativeY>-|)
                                                                       (?<mixedNumberY>\d*\.?\d+)
                                                                     )
                                                                     (?:  \(  |  \s+  )
                                                                   )?
                                                                   (?:
                                                                     (?<entireFractionY>
                                                                       (?<entireNumeratorY>
                                                                         (?<numeratorNegativeY>-|)
                                                                         (?<numeratorY>\d*\.?\d+)
                                                                       )
                                                                       \/
                                                                       (?<entireDenominatorY>
                                                                         (?<denominatorNegativeY>-|)
                                                                         (?<denominatorY>\d*\.?\d+)
                                                                       )
                                                                     )
                                                                     (?:  \)  |  \s+  )?
                                                                   )
                                                                 )
                                                               |
                                                                 (?<entireNumberY>
                                                                   (?<numberNegativeY>-|)
                                                                   (?<numberY>\d*\.?\d+)
                                                                 )
                                                               )
                                                             )                                       
                                                          $", RegexOptions.IgnorePatternWhitespace);
    }
}
