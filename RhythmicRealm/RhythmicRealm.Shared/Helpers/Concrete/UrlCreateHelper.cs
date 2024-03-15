using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.Helpers.Concrete
{
    public static class UrlCreateHelper
    {
        public static string GetUrl(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;
            text = text.Trim();

            text = text.Replace("İ", "i");
            text = text.Replace("I", "i");
            text = text.Replace("ı", "i");

            text = text.ToLower();

            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ş", "s");
            text = text.Replace("ç", "c");
            text = text.Replace("ğ", "g");

            text = text.Replace("\"", "");
            text = text.Replace("'", "");
            text = text.Replace("^", "");
            text = text.Replace("#", "");
            text = text.Replace("+", "");
            text = text.Replace("$", "");
            text = text.Replace("%", "");
            text = text.Replace("&", "");
            text = text.Replace("/", "");
            text = text.Replace("{", "");
            text = text.Replace("}", "");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace("[", "");
            text = text.Replace("]", "");
            text = text.Replace("=", "");
            text = text.Replace("?", "");
            text = text.Replace("*", "");
            text = text.Replace("_", "");
            text = text.Replace("|", "");
            text = text.Replace("<", "");
            text = text.Replace(">", "");
            text = text.Replace(".", "");
            text = text.Replace(":", "");
            text = text.Replace(",", "");
            text = text.Replace("`", "");
            text = text.Replace("~", "");
            text = text.Replace("¨", "");
            text = text.Replace("€", "");
            text = text.Replace("@", "");
            text = text.Replace("!", "");

            string[] splitResult = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            text = String.Join('-', splitResult);
            return text;
        }
    }
}
