using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using minimalWebApiDotNet.Context;
using movieComparatorImdbBack.dto;
using movieComparatorImdbBack.models;
using movieComparatorImdbBack.Services.Services;
using Newtonsoft.Json;


namespace movieComparatorImdbBack.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;

        private readonly MovieService _movieService= new MovieService() ;

        public MovieController(
            ILogger<MovieController> logger
            )
        {
            _logger = logger;
        }

        [HttpGet("/randomMovies")]
        public MovieImdbDto getRandomMovies(string word)
        {
            MovieImdbDto movie1 = _movieService.movieFromRandomWord(word);

            return movie1;

        }

    }
}