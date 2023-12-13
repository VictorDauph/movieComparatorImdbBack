using Microsoft.AspNetCore.Mvc;
using movieComparatorImdbBack.dto;
using movieComparatorImdbBack.Services.Services;

namespace movieComparatorImdbBack.Controllers
{
    [ApiController]
    [Route("/Vote")]
    public class VoteController
    {
        VoteService _voteService = new VoteService();

        [HttpPost("/vote")]
        public void Vote(VoteDto dto)
        {
            _voteService.voteForMovies(dto);
        }

        [HttpGet("/countVotes/{MovieId}")]
        public VoteCountDtoOut countVotes(int MovieId)
        {
            VoteCountDtoOut dto = _voteService.countVotes(MovieId);
            return dto;
        }
    }
}
