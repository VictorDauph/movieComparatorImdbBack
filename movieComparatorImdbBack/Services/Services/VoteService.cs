using movieComparatorImdbBack.dto;
using movieComparatorImdbBack.models;
using movieComparatorImdbBack.Services.EntityService;

namespace movieComparatorImdbBack.Services.Services
{

    public class VoteService
    {
        public UserRepository _userRepository = new UserRepository();
        public MovieRepository _movieRepository = new MovieRepository();
        public VoteRepository _voteRepository = new VoteRepository();
        public void voteForMovies(VoteDto dto)
        {
            User? user = _userRepository.getUserById(dto.userId);
            Movie? moviePos = _movieRepository.getMovieById(dto.IdMoviePos);
            Movie? movieNeg = _movieRepository.getMovieById(dto.IdMovieNeg);

            if (user != null && moviePos != null && movieNeg != null)
            {
                Vote vote = new Vote(user, moviePos.Id, movieNeg.Id);
                _voteRepository.addVote(vote);
                _movieRepository.voteForMovie(moviePos,vote, true);
                _movieRepository.voteForMovie(movieNeg,vote, false);

            }
        }

        public VoteCountDtoOut countVotes(int MovieId)
        {
            int votePosCount = _voteRepository.countVotes(MovieId, true);
            int voteNegCount = _voteRepository.countVotes(MovieId, false);
            VoteCountDtoOut dto= new VoteCountDtoOut(MovieId, votePosCount, voteNegCount);
            return dto;
        }

    }
}
