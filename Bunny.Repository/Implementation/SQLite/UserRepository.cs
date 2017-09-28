using Bunny.Repository.Implementation;
using Bunny.Repository.Interface;
using Bunny.Repository.Schema;

namespace Bunny.Repository.SQLite
{
    public class UserRepository : SQLiteContext, IUserRepository
    {
        public int Insert(UserModel obj)
        {
            var sql = @"
INSERT INTO user
(has_access, cellphone, password, name, surname)
VALUES
(@HasAccess, @CellPhone, @Password, @Name, @Surname);
SELECT last_insert_rowid();";
            return Insert<UserModel>(
                sql,
                obj);
        }

        public UserModel Select(long cellPhone, string password)
        {
            var sql = @"
SELECT * FROM user 
WHERE cellphone = @cellPhone
AND password = @password;";
            return Select<UserModel>(
                sql,
                new { cellPhone, password });
        }
    }
}
