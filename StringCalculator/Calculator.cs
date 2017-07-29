using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private readonly NumberParser[] _parsers;

        public Calculator(NumberParser[] parsers)
        {
            _parsers = parsers;
        }

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
            {
                return 0;
            }

            var parser = _parsers.FirstOrDefault(p => p.CanParse(numbers));

            if (parser == null)
            {
                throw new InvalidOperationException($"No parser found for the current numbers: {numbers}");
            }

            var sumands = parser.ParseNumbers(numbers);

            return sumands.Sum();
        }
    }
}