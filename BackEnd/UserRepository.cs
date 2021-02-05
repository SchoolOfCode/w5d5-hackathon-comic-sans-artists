using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;

public class UserRepository : BaseRepository, IRepository<User>
{
   public IEnumerable<User> GetAllByMonth(string month)
   {
       using var connection = CreateConnection();
       return connection.Query<UserRepository>("SELECT * FROM Users WHERE Month = @Month;", new {Month = month});
   }

   public User Insert(User user)
   {
       using var connection = CreateConnection();
       return connection.QuerySingle<User>("INSERT INTO User (FullName, Day, Month, StarSign) VALUES (@FullName, @Day, @Month, @StarSign) RETURNING *;", user);
   }
}
