using Meetings_API.Models;
using Meetings_API.Models.DataTransferObjects;
using Meetings_API.Repositories;
using Meetings_API.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Meetings_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetingsController : Controller
    {
        private readonly IUnitOfWork repository;

        public MeetingsController(IUnitOfWork repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Meeting> GetMeetings()
        {
            return repository.Meetings.GetMeetings();
        }

        [HttpGet("{id}")]
        public ActionResult<Meeting> GetMeeting(Guid id)
        {
            var meeting = repository.Meetings.GetMeeting(id);

            if (meeting == null)
            {
                return NotFound();
            }

            return meeting;
        }

        [HttpPost]
        public ActionResult<MeetingDTO> CreateMeeting(MeetingDTO meeting)
        {
            Meeting newMeeting = new() {
                Id = Guid.NewGuid(),
                Name = meeting.Name
            };

            repository.Meetings.CreateMeeting(newMeeting);

            return CreatedAtAction(nameof(GetMeeting), new { id = newMeeting.Id }, newMeeting);

        }

        [HttpPut("{id}")]
        public ActionResult UpdateMeeting(Guid id, MeetingDTO meeting)
        {
            var existingMeeting = repository.Meetings.GetMeeting(id);

            if(existingMeeting == null)
            {
                return NotFound();
            }

            existingMeeting.Name = meeting.Name;

            repository.Meetings.UpdateMeeting(existingMeeting);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMeeting(Guid id)
        {
            var existingMeeting = repository.Meetings.GetMeeting(id);

            if (existingMeeting == null)
            {
                return NotFound();
            }

            repository.Meetings.DeleteMeeting(id);

            return NoContent();
        }

        [Route("Users")]
        [HttpGet]
        public IEnumerable<User> MeetingUsers(Guid id)
        {
            return repository.Meetings.GetMeetingUsers(id);
        }

        [Route("Users")]
        [HttpPut]
        public ActionResult AddUserToMeeting(Guid id, Guid userId)
        {
            var existingMeeting = repository.Meetings.GetMeeting(id);
            var existingUser = repository.Users.GetUser(userId);

            if (existingMeeting == null || existingUser == null)
            {
                return NotFound();
            }

            repository.Meetings.AddUserToMeeting(id, existingUser);

            return NoContent();
        }

        [Route("Users")]
        [HttpDelete]
        public ActionResult RemoveUserFromMeeting(Guid id, Guid userId)
        {
            var existingMeeting = repository.Meetings.GetMeeting(id);
            var existingUser = repository.Users.GetUser(userId);

            if (existingMeeting == null || existingUser == null)
            {
                return NotFound();
            }

            repository.Meetings.RemoveUserFromMeeting(id, existingUser);

            return NoContent();
        }
    }
}
