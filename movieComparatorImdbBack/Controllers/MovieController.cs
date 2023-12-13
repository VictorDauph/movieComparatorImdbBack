using Microsoft.AspNetCore;
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
    [Route("/Movie")]
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;

        private readonly IWebHostEnvironment _webHost;

        private readonly MovieService _movieService;

        public MovieController(
            ILogger<MovieController> logger,
            IWebHostEnvironment webHost
            )
        {
            _webHost = webHost;
            _logger = logger;
            _movieService = new MovieService(_webHost);
        }

        [HttpGet("/randomMovies")]
        public ICollection<MovieImdbDto>? getRandomMovies()
        {
  

            ICollection<MovieImdbDto>? movieDuo = _movieService.BuildMovieDuo();

            return movieDuo;

        }

    }
}