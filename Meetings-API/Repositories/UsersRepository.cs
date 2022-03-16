using Meetings_API.Models;

namespace Meetings_API.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly List<User> users = new()
        {
            new User
            {
                Id = Guid.NewGuid(),
                Name = "Dave",
                Email = "dave.parker@gmail.com"
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "Pete",
                Email = "pete011@gmail.com"
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "Emma",
                Email = "emma.wat15@gmail.com"
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "James",
                Email = "james.bond007@gmail.com"
            },

        };

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User GetUser(Guid id)
        {
            return users.SingleOrDefault(m => m.Id == id);
        }

        public void CreateUser(User user)
        {
            users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var index = users.FindIndex(existingMeeting => existingMeeting.Id == user.Id);
            users[index] = user;
        }

        public void DeleteUser(Guid id)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == id);
            users.RemoveAt(index);
        }
    }
}
