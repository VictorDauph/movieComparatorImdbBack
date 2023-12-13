using movieComparatorImdbBack.dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieComparatorImdbBack.models
{
    public class Vote
    {
        private Vote() { }

        public Vote(User user, int moviePosid, int movieNegid) {
            this.UserId = user.Id;
            this.MoviePosId = moviePosid;
            this.MovieNegId = movieNegid;   
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int MoviePosId { get; set; }

        public int MovieNegId { get; set; }




    }
}
