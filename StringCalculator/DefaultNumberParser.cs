using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class DefaultNumberParser : NumberParser
    {
        private static readonly Regex StartWithWhiteSpaceOrNumber = new Regex("^\\s|[0-9]+");

        public override bool CanParse(string input)
        {
            return StartWithWhiteSpaceOrNumber.IsMatch(input);
        }

        public override IEnumerable<int> ParseNumbers(string input)
        {
            var delimiters = new[] { ",", "\n" };

            return SplitAndParse(input, delimiters);
        }
    }
}