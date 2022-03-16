using Meetings_API.Repositories.IRepositories;

namespace Meetings_API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IMeetingsRepository meetings, IUsersRepository users)
        {
            Meetings = meetings;
            Users = users;
        }

        public IMeetingsRepository Meetings {get; private set;}

        public IUsersRepository Users { get; private set; }
    }
}
