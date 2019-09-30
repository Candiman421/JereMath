using System;
using System.Collections.Generic;
using System.Text;

namespace JereMath.Library.JereMath.Extensions
{
    public static class ExpressionExtensions
    {
        public static List<string> TopLevelParentheticallyClosedGroups(this string givenValue)
        {
            var groups = new List<string>();
            for (int i = 0; i < givenValue.Length; i++)
            {
                if (givenValue[i] == '(')
                {
                    var sb = new StringBuilder();
                    sb.Append(givenValue[i]);
                    i++;
                    var nestedUnclosedCount = 0;
                    for (; i < givenValue.Length; i++)
                    {
                        if (givenValue[i] == ')')
                        {
                            if (nestedUnclosedCount == 0)
                            {
                                sb.Append(givenValue[i]);
                                groups.Add(sb.ToString());
                                break;
                            }
                            else
                            {
                                nestedUnclosedCount--;
                                sb.Append(givenValue[i]);
                            }
                        }
                        else
                        {
                            if (i == givenValue.Length - 1)
                            {
                                throw new Exception("Parenthesis not closed");
                            }
                            else
                            {
                                if (givenValue[i] == '(')
                                {
                                    nestedUnclosedCount++;
                                    sb.Append(givenValue[i]);
                                }
                                else
                                {
                                    sb.Append(givenValue[i]);
                                }
                            }
                        }
                    }
                }
            }
            return groups;
        }

        public static List<string> RemoveOuterParenthesis(this List<string> parentheticalGroups)
        {
            for (int i = 0; i < parentheticalGroups.Count; i++)
            {
                parentheticalGroups[i] = parentheticalGroups[i].RemoveOuterParenthesis();
            }

            return parentheticalGroups;
        }

        public static string RemoveOuterParenthesis(this string parentheticalGroup)
        {
            if (parentheticalGroup.StartsWith("(") && parentheticalGroup.EndsWith(")"))
            {
                return parentheticalGroup.RemoveFirst().RemoveLast();
            }
            else
            {
                throw new Exception("Must have outer parenthesis to remove them");
            }
        }

        public static string RemoveOuterParenthesisIfExists(this string parentheticalGroup)
        {
            var retVal = parentheticalGroup;
            if (retVal.StartsWith("("))
            {
                retVal = retVal.RemoveFirst();
            }

            if (retVal.StartsWith(")"))
            {
                retVal = retVal.RemoveLast();
            }
            return retVal;
        }
    }
}
