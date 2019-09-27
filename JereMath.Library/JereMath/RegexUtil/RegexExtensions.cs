using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JereMath.Library.JereMath.RegexUtil
{
    public static class RegexExtensions
    {
        public static Dictionary<string, string> MatchNamedCaptures(this Regex regex, string input) //https://stackoverflow.com/questions/1381097/how-do-i-get-the-name-of-captured-groups-in-a-c-sharp-regex
        {
            var namedCaptureDictionary = new Dictionary<string, string>();
            GroupCollection groups = regex.Match(input).Groups;
            string[] groupNames = regex.GetGroupNames();
            foreach (string groupName in groupNames)
            {
                namedCaptureDictionary.Add(groupName, groups[groupName].Value);
            }
            return namedCaptureDictionary;
        }
        public static List<Dictionary<string, string>> MatchNamedCapturesCollection(this Regex regex, string input) //https://stackoverflow.com/questions/1381097/how-do-i-get-the-name-of-captured-groups-in-a-c-sharp-regex
        {
            var results = new List<Dictionary<string, string>>();
            MatchCollection mc = regex.Matches(input);
            foreach (Match match in mc)
            {
                var namedCaptureDictionary = new Dictionary<string, string>();
                GroupCollection groups = match.Groups;
                string[] groupNames = regex.GetGroupNames();
                foreach (string groupName in groupNames)
                {
                    namedCaptureDictionary.Add(groupName, groups[groupName].Value);
                }

                results.Add(namedCaptureDictionary);
            }
            return results;
        }
    }
}
