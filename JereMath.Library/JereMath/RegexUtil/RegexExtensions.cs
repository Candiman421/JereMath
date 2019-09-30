using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using JereMath.Library.JereMath.Enums;
using JereMath.Library.JereMath.Extensions;

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
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
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


        public static List<string> GetCapturesByGroupName(this Regex regex, string input, RegexCaptureName nameOfGroup)
        {
            var results = new List<string>();
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                string[] groupNames = regex.GetGroupNames();
                foreach (string groupName in groupNames)
                {
                    if (groupName == nameOfGroup.Name())
                    {
                        foreach (Capture capture in groups[groupName].Captures)
                        {
                            results.Add(capture.Value);
                        }
                        return results;
                    }
                }
            }
            return null;
        }

        public static List<string> GetMatchCaptures(this MatchCollection matches)
        {
            var results = new List<string>();
            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    results.Add(capture.Value);
                }
            }
            return results;
        }
    }
}
