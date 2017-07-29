using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public abstract class NumberParser
    {
        public abstract bool CanParse(string input);

        public abstract IEnumerable<int> ParseNumbers(string input);

        protected static IEnumerable<int> SplitAndParse(string numbers, string[] delimiters)
        {
            return numbers
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}