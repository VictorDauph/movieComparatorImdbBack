using movieComparatorImdbBack.dto;

namespace movieComparatorImdbBack.Services.Services
{
    public class MovieService
    {
        ImdbConnectorService _connectorService = new ImdbConnectorService();
        public MovieService() { }

        public MovieImdbDto movieFromRandomWord(string word)
        {
            // On requête un premier dto à partir du mot clé
            TmdbSearchResultDto tmdbSearchResultDtoinit = _connectorService.fetchSearchResultDto(word, 1).Result;

            //On requête une page du dto au hasard
            TmdbSearchResultDto tmdbSearchResultDtoRandom = _connectorService.fetchARandomPage(word, tmdbSearchResultDtoinit.total_pages);

            //On retourne un film au hasard dans le dto
            return _connectorService.selectRandomMovie(tmdbSearchResultDtoRandom);
        }
    }
}
