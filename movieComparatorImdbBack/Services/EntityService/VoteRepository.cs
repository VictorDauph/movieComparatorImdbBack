using Microsoft.EntityFrameworkCore;
using minimalWebApiDotNet.Context;
using movieComparatorImdbBack.models;

namespace movieComparatorImdbBack.Services.EntityService
{
    public class VoteRepository
    {
        DataContext _dataContext = new DataContext();
        public void addVote(Vote vote)
        {
            _dataContext.Votes.Add(vote);
            _dataContext.SaveChanges();
        }

        public int countVotes(int idMovie, bool VotePositivity)
        {

            FormattableString request = $"SELECT * FROM dbo.VOTES WHERE MoviePosId = {idMovie}";
            FormattableString requestNeg = $"SELECT * FROM dbo.VOTES WHERE MovieNegId = {idMovie}";
            if (!VotePositivity)
            {
                 request = requestNeg ;
            }

            int count = _dataContext.Votes.FromSql(
                request
                    ).Count();
            return count;
        }

    }
}
