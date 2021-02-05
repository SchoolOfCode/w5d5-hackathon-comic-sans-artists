// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;

<<<<<<< HEAD

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IRepository<User> _userRepository;

    public UserController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
||||||| a51ba08
namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
=======
// namespace BackEnd.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class WeatherForecastController : ControllerBase
//     {
//         private static readonly string[] Summaries = new[]
//         {
//             "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//         };
>>>>>>> a950cb8e1bae8ee1eeb306b0ded7624d91233aac

<<<<<<< HEAD
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try {
            var books = await _bookRepository.GetAll();
||||||| a51ba08
        private readonly ILogger<WeatherForecastController> _logger;
=======
//         private readonly ILogger<WeatherForecastController> _logger;
>>>>>>> a950cb8e1bae8ee1eeb306b0ded7624d91233aac

<<<<<<< HEAD
            return Ok(books);
        }
        catch(Exception){

            return NotFound();
        }
    }
||||||| a51ba08
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
=======
//         public WeatherForecastController(ILogger<WeatherForecastController> logger)
//         {
//             _logger = logger;
//         }
>>>>>>> a950cb8e1bae8ee1eeb306b0ded7624d91233aac

<<<<<<< HEAD

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try {
            var book = await _bookRepository.Get(id);

            return Ok(book);
        }
        catch (Exception){
            return NotFound($"/books/{id} Not Found");
        }
    }

    [HttpDelete("{id}")]
    public async void Delete(long id)
    {
        try
        {
            await _bookRepository.Delete(id);
        }
        catch(Exception){

            NotFound($"/books/{id} Not Found"); //this appears to never get returned
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] Book book)
    {
        try {
            var updatedBook = await _bookRepository.Update(new Book { Id = id, Title = book.Title, Author = book.Author });

            return Ok(updatedBook);
        }
        catch(Exception){

            return NotFound($"/books/{id} Not Found");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] Book book)
    {
        try {
            var newBook = await _bookRepository.Insert(book);
            return Created($"/books/{book.Id}", newBook);
        }
        catch (Exception){

            return BadRequest("Could not create book, check request and try again.");
        }
    }
}

||||||| a51ba08
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
=======
//         [HttpGet]
//         public IEnumerable<WeatherForecast> Get()
//         {
//             var rng = new Random();
//             return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//             {
//                 Date = DateTime.Now.AddDays(index),
//                 TemperatureC = rng.Next(-20, 55),
//                 Summary = Summaries[rng.Next(Summaries.Length)]
//             })
//             .ToArray();
//         }
//     }
// }
>>>>>>> a950cb8e1bae8ee1eeb306b0ded7624d91233aac
