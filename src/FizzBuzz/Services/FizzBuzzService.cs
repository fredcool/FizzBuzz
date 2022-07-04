using Microsoft.Extensions.Options;

namespace FizzBuzz.Services
{
    public class FizzBuzzResult
    {
        public FizzBuzzResult()
        {
            Lines = new();
        }

        public List<string> Lines { get; }
    }

    public class DivisorConfig
    {
        public string? PrintedWord { get; set; }

        public int Divisor { get; set; }
    }

    public class FizzBuzzConfig
    {
        public FizzBuzzConfig()
        {
            DivisorConfigs = new();
        }

        public int MaxNumber { get; set; }

        public List<DivisorConfig> DivisorConfigs { get; }
    }

    public class FizzBuzzService
    {
        public FizzBuzzService()
        {

        }

        public FizzBuzzResult FizzBuzz(Action<FizzBuzzConfig> configInitiator)
        {
            FizzBuzzConfig config = new();
            configInitiator.Invoke(config);
            return DoFizzBuzz(config);
        }

        private static FizzBuzzResult DoFizzBuzz(FizzBuzzConfig config)
        {
            FizzBuzzResult result = new();
            for (int i = 1; i <= config.MaxNumber; i++)
            {
                var printedWord = string.Join("", config.DivisorConfigs.Select(divisorConfig =>
                {
                    return (i % divisorConfig.Divisor == 0) ? divisorConfig.PrintedWord : "";
                }));
                result.Lines.Add(string.IsNullOrEmpty(printedWord) ? i.ToString() : printedWord);
            }
            return result;
        }
    }
}
