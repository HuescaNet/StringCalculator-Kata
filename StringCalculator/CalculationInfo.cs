namespace StringCalculator
{
    public class CalculationInfo
    {
        private CalculationInfo(string[] delimiter, string input)
        {
            Delimiters = delimiter;
            Input = input;
        }

        public string[] Delimiters { get; }

        public string Input { get; }

        public static CalculationInfo Default(string input)
        {
            return new CalculationInfo(new[] { ",", "\n" }, input);
        }

        public static CalculationInfo WithCustomDelimiters(string[] delimiters, string input)
        {
            return new CalculationInfo(delimiters, input);
        }
    }
}