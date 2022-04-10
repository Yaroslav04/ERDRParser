using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ERDRParser.Core
{
    public static class TextServise
    {
        public static string GetCriminalnumber(string _value)
        {
            Regex regex = new Regex(@"\d(20)\d\d\d\d\d\d\d\d\d\d\d\d\d\d");
            MatchCollection matches = regex.Matches(_value);
            if (matches.Count > 0)
            {
                return matches[0].Value;
            }

            return "";
        }
    }
}
