namespace movieComparatorImdbBack.dto
{
    public class MovieImdbDto
    {
        //ID TMDB
        public int Id { get; set; }

        public string original_title { get; set; } = null!;

        public string title { get; set; } = null!;

        public string overview { get; set; } = null!;

        public string poster_path { get; set; } = null!;
    }

}
