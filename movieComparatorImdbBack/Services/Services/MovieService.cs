using movieComparatorImdbBack.dto;
using movieComparatorImdbBack.models;
using movieComparatorImdbBack.Services.EntityService;

namespace movieComparatorImdbBack.Services.Services
{
    public class MovieService
    {
        private readonly IWebHostEnvironment _webHost;
        ImdbConnectorService _connectorService = new ImdbConnectorService();
        private readonly WordsService _wordsService;
        private readonly WordsRepository _wordsRepository = new WordsRepository();
        private readonly MovieRepository _movieRepository = new MovieRepository();

        public MovieService(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
            _wordsService = new WordsService(_webHost);
        }





        public IList<MovieImdbDto>? BuildMovieDuo()
        {

            MovieImdbDto? movieDto1 = this.movieFromRandomWord();
            MovieImdbDto? movieDto2 = this.movieFromRandomWord();

            if(movieDto1 == null || movieDto2 == null) return null;
            else
            {
                copyMovieData(movieDto1);
                copyMovieData(movieDto2);
                IList<MovieImdbDto> movieDuo = new List<MovieImdbDto>();
                movieDuo.Add(movieDto1);
                movieDuo.Add(movieDto2);
                return movieDuo;
            }

        }
        public MovieImdbDto? movieFromRandomWord()
        {
            
            Boolean movieFound = false;
            while (!movieFound)
            {
                WordClass wordClass = _wordsService.getRandomWord();
                // On requête un premier dto à partir du mot clé
                TmdbSearchResultDto tmdbSearchResultDtoinit = _connectorService.fetchSearchResultDto(wordClass.Word, 1).Result;

                if (tmdbSearchResultDtoinit.results.Count == 0)
                {
                    //todo s'il n'ya pas de résultat on supprime le mot du dictionnaire et on recommence la requête 
                    _wordsRepository.deleteWord(wordClass);
                    Console.WriteLine(wordClass.Word + " deleted");

                }
                else
                {
                    //On requête une page du dto au hasard
                    TmdbSearchResultDto tmdbSearchResultDtoRandom = _connectorService.fetchARandomPage(wordClass.Word, tmdbSearchResultDtoinit.total_pages);

                    //On retourne un film selectionné au hasard dans le dto
                    return _connectorService.selectRandomMovie(tmdbSearchResultDtoRandom);

                }
            }
            return null;

        }

        public void copyMovieData(MovieImdbDto dto)
        {
            Movie? movie = _movieRepository.getMovieById(dto.Id);

            if(movie == null) {
                movie = new Movie(dto);
                _movieRepository.addMovie(movie);
            }
        }
    }
}
