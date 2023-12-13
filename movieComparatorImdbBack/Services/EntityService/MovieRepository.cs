using minimalWebApiDotNet.Context;
using movieComparatorImdbBack.models;

namespace movieComparatorImdbBack.Services.EntityService
{
    public class MovieRepository
    {
        DataContext _dataContext;
        public MovieRepository()
        {
            this._dataContext = new DataContext();
        }

        public Movie? getMovieById(int Id)
        {
            try
            {
                Movie? movie = _dataContext.Movies
                    .FromSql(
                            $"SELECT TOP 1 * FROM dbo.Movies WHERE Id = {Id}")
                    .First();
                return movie;
            }catch (Exception ex)
            {
                Console.WriteLine( ex.ToString() );
                return null;
            }

        }

        public Movie? getMovieByTmdbId(int TmdbId)
        {
            try
            {
                Movie? movie = _dataContext.Movies
                    .FromSql(
                            $"SELECT TOP 1 * FROM dbo.Movies WHERE TmdbId = {TmdbId}")
                    .First();
                return movie;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }
        public void addMovie( Movie movie )
        {
            _dataContext.Movies.Add( movie );
            _dataContext.SaveChanges();
        }

        //bool vote is true for positive vote and false for negative vote
        public void voteForMovie( Movie movie,Vote vote, bool votePos ) {

            /*
            if( votePos == true ) {
                movie.votePosId.Add(vote.Id);
            }
            if(votePos == false)
            {
                movie.voteNegId.Add(vote.Id); ;
            }

            _dataContext.SaveChanges();
            */
            
        }
    }
}
