using movieComparatorImdbBack.dto;
using movieComparatorImdbBack.models;

namespace movieComparatorImdbBack.Services.Services
{
    public class MovieService
    {
        ImdbConnectorService _connectorService = new ImdbConnectorService();
        private readonly WordsService _wordsService = new WordsService();
        public MovieService() { }

        public IList<MovieImdbDto>? BuildMovieDuo()
        {
            WordClass word1 = _wordsService.getRandomWord();
            WordClass word2 = _wordsService.getRandomWord();

            MovieImdbDto? movie1 = this.movieFromRandomWord(word1);
            MovieImdbDto? movie2 = this.movieFromRandomWord(word2);

            if(movie1 == null || movie2 == null) return null;
            else
            {
                IList<MovieImdbDto> movieDuo = new List<MovieImdbDto>();
                movieDuo.Add(movie1);
                movieDuo.Add(movie2);
                return movieDuo;
            }

        }
        public MovieImdbDto? movieFromRandomWord(WordClass wordClass)
        {
            // On requête un premier dto à partir du mot clé
            TmdbSearchResultDto tmdbSearchResultDtoinit = _connectorService.fetchSearchResultDto(wordClass.Word , 1).Result;
            if(tmdbSearchResultDtoinit.results.Count == 0) {
                //todo s'il n'ya pas de résultat on supprime le mot du dictionnaire et on recommence la requête 
                return null;
            }
            else
            {
                //On requête une page du dto au hasard
                TmdbSearchResultDto tmdbSearchResultDtoRandom = _connectorService.fetchARandomPage(wordClass.Word, tmdbSearchResultDtoinit.total_pages);

                //On retourne un film selectionné au hasard dans le dto
                return _connectorService.selectRandomMovie(tmdbSearchResultDtoRandom);

            }
        }
    }
}
