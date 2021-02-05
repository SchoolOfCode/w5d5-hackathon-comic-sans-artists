using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;

public class UserRepository : BaseRepository, IRepository<User>
{
    public UserRepository(IConfiguration configuration) : base(configuration) { }
    public async Task<IEnumerable<User>> GetAll()
   {
       using var connection = CreateConnection();

       return await connection.QueryAsync<User>("SELECT * FROM Users ORDER BY id;");
   }
    public async Task<IEnumerable<User>> GetAllByMonth(string month)
   {
       using var connection = CreateConnection();

       return await connection.QueryAsync<User>("SELECT * FROM Users WHERE Month = @Month;", new {Month = month});
   }

   public async Task<User> Insert(User user)
   {
       using var connection = CreateConnection();

       return await connection.QuerySingleAsync<User>("INSERT INTO Users (FullName, Day, Month, StarSign) VALUES (@FullName, @Day, @Month, @StarSign) RETURNING *;", user);
   }
}
