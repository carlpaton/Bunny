using Bunny.Repository.Schema;

namespace Bunny.Repository.Interface
{
    public interface IUserRepository
    {
        UserModel Select(long cellPhone, string password);
        int Insert(UserModel obj);
    }
}
