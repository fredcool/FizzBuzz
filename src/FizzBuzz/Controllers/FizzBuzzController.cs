using FizzBuzz.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Controllers
{
    public class DivisorModel
    {
        public int Divisor { get; set; }

        public string PrintedWord { get; set; } = "";
    }
    public class InputModel
    {
        public int MaxNumber { get; set; }
        public List<DivisorModel>? Divisors { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        private readonly FizzBuzzService _fizzBuzzService;
        public FizzBuzzController(FizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost]
        public ActionResult Post(InputModel model)
        {
            var result = _fizzBuzzService.FizzBuzz((config) =>
            {
                config.MaxNumber = model.MaxNumber;
                if (model.Divisors != null)
                {
                    model.Divisors.ForEach(d =>
                    {
                        config.DivisorConfigs.Add(new()
                        {
                            Divisor = d.Divisor,
                            PrintedWord = d.PrintedWord
                        });
                    });
                }
            });
            return Ok(result);
        }
    }
}
