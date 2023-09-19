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

        private readonly ImdbConnectorService _imdbConnectorService;

        public MovieController(
            ILogger<MovieController> logger
            )
        {
            _logger = logger;
            _imdbConnectorService = new ImdbConnectorService();
        }

        [HttpGet("/randomMovies")]
        public string getRandomMovies()
        {
            Task<string> response= _imdbConnectorService.movieFromRandomWord("the");

            TmdbSearchResultDto tmdbSearchResultDto= JsonConvert.DeserializeObject<TmdbSearchResultDto>(response.Result);

            return response.Result ;

        }

    }
}