namespace movieComparatorImdbBack.dto
{
    public class VoteCountDtoOut
    {
        public int MovieId { get; set;}
        public int VotePosCount { get; set;} 
        public int VoteNegCount { get; set;}
        public VoteCountDtoOut(int MovieId, int VotePosCount, int VoteNegCount ) {
            this.MovieId = MovieId;
            this.VotePosCount = VotePosCount;
            this.VoteNegCount = VoteNegCount;
        }

    }
}
