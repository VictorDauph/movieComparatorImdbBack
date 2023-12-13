using minimalWebApiDotNet.Context;
using movieComparatorImdbBack.models;

namespace movieComparatorImdbBack.Services.EntityService
{
    public class UserRepository
    {
        DataContext _dataContext;
        public UserRepository()
        {
            this._dataContext = new DataContext();
        }

        public User? getUserById(int id)
        {
            User? user = _dataContext.Users
                                .FromSql(
                                        $"SELECT TOP 1 * FROM dbo.Users WHERE id = {id}  ")
                                .First();
            return user;
        }

        public void addUser(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
        }
    }
}
