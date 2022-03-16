using Meetings_API.Models;

namespace Meetings_API.Repositories
{
    public class MeetingsRepository : IMeetingsRepository
    {
        private readonly List<Meeting> meetings = new()
        {
            new Meeting
            {
                Id = Guid.NewGuid(),
                Name = "Algebra First Meeting"
            },
            new Meeting
            {
                Id = Guid.NewGuid(),
                Name = "Calculus Exam"
            },
            new Meeting
            {
                Id = Guid.NewGuid(),
                Name = "C# crash course"
            },
            new Meeting
            {
                Id = Guid.NewGuid(),
                Name = "Web programming"
            },
            new Meeting
            {
                Id = Guid.NewGuid(),
                Name = "Java OOP course"
            }
        };

        public IEnumerable<Meeting> GetMeetings()
        {
            return meetings;
        }

        public Meeting GetMeeting(Guid id)
        {
            return meetings.SingleOrDefault(m => m.Id == id);
        }

        public void CreateMeeting(Meeting meeting)
        {
            meetings.Add(meeting);
        }

        public void UpdateMeeting(Meeting meeting)
        {
            var index = meetings.FindIndex(existingMeeting => existingMeeting.Id == meeting.Id);
            meetings[index] = meeting;
        }

        public void DeleteMeeting(Guid id)
        {
            var index = meetings.FindIndex(existingMeeting => existingMeeting.Id == id);
            meetings.RemoveAt(index);
        }

        public IEnumerable<User> GetMeetingUsers(Guid id)
        {
            var existingMeeting = meetings.SingleOrDefault(m => m.Id == id);
            return existingMeeting.Users;
        }

        public void AddUserToMeeting(Guid id, User user)
        {
            var existingMeeting = meetings.SingleOrDefault(m => m.Id == id);
            existingMeeting.Users.Add(user);
        }

        public void RemoveUserFromMeeting(Guid id, User user)
        {
            var existingMeeting = meetings.SingleOrDefault(m => m.Id == id);
            existingMeeting.Users.Remove(user);
        }
    }
}
