using Meetings_API.Models;
using Meetings_API.Models.DataTransferObjects;
using Meetings_API.Repositories;
using Meetings_API.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Meetings_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork repository;

        public UsersController(IUnitOfWork repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<User> GetMeetings()
        {
            return repository.Users.GetUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(Guid id)
        {
            var user = repository.Users.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<UserDTO> CreateMeeting(UserDTO user)
        {
            User newUser = new() {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Email = user.Email,
            };

            repository.Users.CreateUser(newUser);

            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);

        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UserDTO meeting)
        {
            var existingUser = repository.Users.GetUser(id);

            if(existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = meeting.Name;
            existingUser.Email = meeting.Email;

            repository.Users.UpdateUser(existingUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMeeting(Guid id)
        {
            var existingUser = repository.Users.GetUser(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            repository.Users.DeleteUser(id);

            return NoContent();
        }
    }
}
