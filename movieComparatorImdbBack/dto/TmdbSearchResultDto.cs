namespace movieComparatorImdbBack.dto
{
    public class TmdbSearchResultDto
    {
        public int page { get; set; }

        public IList<MovieImdbDto> results { get; set; } = null!;

        public int total_pages { get; set; }

        public int total_results { get; set; }
    }
}
