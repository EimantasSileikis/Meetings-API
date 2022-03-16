using Meetings_API.Models;

namespace Meetings_API.Repositories
{
    public interface IUsersRepository
    {
        User GetUser(Guid id);
        IEnumerable<User> GetUsers();
        void CreateUser(User meeting);
        void UpdateUser(User meeting);
        void DeleteUser(Guid id);
    }
}