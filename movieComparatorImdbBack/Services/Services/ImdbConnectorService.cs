using movieComparatorImdbBack.dto;
using Newtonsoft.Json;

namespace movieComparatorImdbBack.Services.Services
{
    public class ImdbConnectorService
    {
        HttpClient httpClient = new HttpClient();

        public async Task<TmdbSearchResultDto> fetchSearchResultDto(string word,int page)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.themoviedb.org/3/search/keyword?query=" + word + "&page="+page+"&api_key=e3ddd4b9392b10229880876e06626f24")
            };

            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            Task<string> responseString = response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TmdbSearchResultDto>(responseString.Result);
        }

        public TmdbSearchResultDto fetchARandomPage(string word,int totalPages) {
            
            Random random = new Random();
            int randomPageNumer=random.Next(1,totalPages);

            return fetchSearchResultDto(word,randomPageNumer).Result;
        }

        public MovieImdbDto selectRandomMovie(TmdbSearchResultDto searchResultDto)
        {
            Random random = new Random();
            int resultsCount = searchResultDto.results.Count();
            int randomMovieIndex = random.Next(0,resultsCount);

            return searchResultDto.results[randomMovieIndex];

        }

    }
}
