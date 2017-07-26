namespace StringCalculator
{
    public class NumbersFormatter
    {
        private const string CustomDelimiterStart = "//";

        public CalculationInfo Parse(string numbers)
        {
            var hasCustomDelimiter = numbers.StartsWith(CustomDelimiterStart);

            if (hasCustomDelimiter)
            {
                return ManageCustomDelimiter(numbers);
            }
            else
            {
                return CalculationInfo.Default(numbers);
            }
        }

        private static CalculationInfo ManageCustomDelimiter(string numbers)
        {
            var delimiterSeparatorIndex = numbers.IndexOf('\n');
            var delimiters = new[] { numbers.Substring(CustomDelimiterStart.Length, delimiterSeparatorIndex - CustomDelimiterStart.Length) };
            var localNumbers = numbers.Substring(delimiterSeparatorIndex + 1);

            return CalculationInfo.WithCustomDelimiters(delimiters, localNumbers);
        }
    }
}