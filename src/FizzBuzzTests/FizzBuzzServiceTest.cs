using FizzBuzz.Services;

namespace FizzBuzzTests
{
    public class FizzBuzzServiceTest
    {
        public readonly List<string> ExpectedResult = new()
        {
            "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"
        };

        private FizzBuzzService _service;

        public FizzBuzzServiceTest()
        {
            _service = new();
        }

        [Fact]
        public void TestFizzBuzz()
        {
            var actual = _service.FizzBuzz(config =>
            {
                config.MaxNumber = 15;
                config.DivisorConfigs.Add(new()
                {
                    PrintedWord = "Fizz",
                    Divisor = 3
                });
                config.DivisorConfigs.Add(new()
                {
                    PrintedWord = "Buzz",
                    Divisor = 5
                });
            });
            Assert.Equal(ExpectedResult, actual.Lines);
        }

        [Fact]
        public void TestFizzBuzzNoDivisor()
        {
            var actual = _service.FizzBuzz(config =>
            {
                config.MaxNumber = 200;
            });
        }

        [Fact]
        public void TestFizzBuzz_100()
        {
            var actual = _service.FizzBuzz(config =>
            {
                config.MaxNumber = 200;
                config.DivisorConfigs.Add(new()
                {
                    PrintedWord = "Fizz",
                    Divisor = 3
                });
                config.DivisorConfigs.Add(new()
                {
                    PrintedWord = "Buzz",
                    Divisor = 5
                });
                config.DivisorConfigs.Add(new()
                {
                    PrintedWord = "Jazz",
                    Divisor = 7
                });
            });
        }
    }
}