using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProcessingUnansweredRequest
{
    public class UnansweredRequestProcessor
    {
        public string GetKey(string inputAnswer)
        {
            var rgx = new Regex("(([А-Яа-яіІїЇєЄ]){3,})");
            var allMatches = rgx.Matches(inputAnswer);

            var words = new StringBuilder(allMatches.Count);
            for (int i = 0; i < allMatches.Count; i++)
            {
                string prefix = i == 0 ? "{0}" : "+{0}";
                words.AppendFormat(prefix, allMatches[i]);
            }

            return words.ToString();
        }
    }
}
