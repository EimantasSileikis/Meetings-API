using Meetings_API.Models;

namespace Meetings_API.Repositories
{
    public interface IMeetingsRepository
    {
        Meeting GetMeeting(Guid id);
        IEnumerable<Meeting> GetMeetings();
        void CreateMeeting(Meeting meeting);
        void UpdateMeeting(Meeting meeting);
        void DeleteMeeting(Guid id);
        IEnumerable<User> GetMeetingUsers(Guid id);
        void AddUserToMeeting(Guid id, User user);
        void RemoveUserFromMeeting(Guid id, User user);
    }
}