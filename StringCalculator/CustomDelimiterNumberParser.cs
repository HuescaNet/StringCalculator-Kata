using System.Collections.Generic;

namespace StringCalculator
{
    public class CustomDelimiterNumberParser : NumberParser
    {
        private const string CustomDelimiterMark = "//";

        public override bool CanParse(string input)
        {
            return input.StartsWith(CustomDelimiterMark);
        }

        public override IEnumerable<int> ParseNumbers(string input)
        {
            var delimiterSeparatorIndex = input.IndexOf('\n');
            var start = CustomDelimiterMark.Length;
            var length = delimiterSeparatorIndex - CustomDelimiterMark.Length;

            var delimiters = new[] { input.Substring(start, length) };
            var numbers = input.Substring(delimiterSeparatorIndex + 1);

            return SplitAndParse(numbers, delimiters);
        }
    }
}