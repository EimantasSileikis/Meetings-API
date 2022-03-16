namespace Meetings_API.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IMeetingsRepository Meetings { get; }
        IUsersRepository Users { get; }
    }
}
