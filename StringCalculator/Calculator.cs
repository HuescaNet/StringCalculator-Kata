using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private readonly NumbersFormatter _formatter;

        public Calculator(NumbersFormatter formatter)
        {
            _formatter = formatter;
        }

        public int Add(string numbers)
        {
            if (numbers == string.Empty)
            {
                return 0;
            }

            var calculationInfo = _formatter.Parse(numbers);

            return calculationInfo.Input
                .Split(calculationInfo.Delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .Sum();
        }
    }
}