using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizXamarin.Regexs
{
    public static class YoutubeRegex
    {
        public static string ObtenerId(string url)
        {
            string ResultString = null;
            try
            {
                ResultString = Regex.Match(url, 
                    "https?:\\/\\/(?:[0-9A-Z-]+\\.)?(?:youtu\\.be\\/|youtube(?:-nocookie)?\\.com\\S*[^\\w\\s-])([\\w-]{11})(?=[^\\w-]|$)(?![?=&+%\\w.-]*(?:['\"][^<>]*>|<\\/a>))[?=&+%\\w.-]*",
                    RegexOptions.IgnoreCase).Groups[1].Value;

                return ResultString;
              //  string thumbimg = String.Format("http://img.youtube.com/vi/{0}/default.jpg", ResultString);
            }
            catch (ArgumentException ex)
            {
                return "";
                // Syntax error in the regular expression
            }
        }
    }
}
