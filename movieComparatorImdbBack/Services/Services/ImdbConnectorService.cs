using movieComparatorImdbBack.dto;

namespace movieComparatorImdbBack.Services.Services
{
    public class ImdbConnectorService
    {
        HttpClient httpClient = new HttpClient();

        public async Task<string> movieFromRandomWord(string word)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.themoviedb.org/3/search/keyword?query="+word+"&page=1&api_key=e3ddd4b9392b10229880876e06626f24")
            };

            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();


            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        public ICollection<MovieImdbDto> moviesFromRandomWords(string word1,string word2)
        {
            //générer mots aléatoires
            //utiliser movieFromRandomWord pour trouver des films
            //Gérer un système pour que la recherche aléatoire se fasse sur une page aléatoire
        }
    }
}
