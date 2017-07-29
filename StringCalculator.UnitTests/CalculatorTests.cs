using FluentAssertions;
using Moq;
using Xunit;

namespace StringCalculator.UnitTests
{
    public class CalculatorTests
    {
        private readonly Calculator _sut;

        public CalculatorTests()
        {
            _sut = new Calculator(new NumberParser[]
            {
                new CustomDelimiterNumberParser(),
                new DefaultNumberParser()
            });
        }

        [Fact]
        public void Empty_Numbers_Returns_0()
        {
            var result = _sut.Add("");

            result.Should().Be(0);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("999", 999)]
        public void Numbers_With_One_Number_Returns_Number(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("2,1", 3)]
        [InlineData(" 2 , 1 ", 3)]
        [InlineData("99,99", 198)]
        [InlineData("1,2,3,4,5,6", 21)]
        public void Numbers_With_Several_Numbers_Returns_Numbers_Sum_With_Comma_Separators(
            string numbers,
            int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("1,2\n3", 6)]
        public void Numbers_With_Severals_Numbers_Returns_Numbers_Sum_With_Different_Delimiters(
            string numbers,
            int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//patata\n1patata2", 3)]
        public void Can_Define_Custom_Delimiter(string numbers, int expected)
        {
            var result = _sut.Add(numbers);

            result.Should().Be(expected);
        }

    }
}
