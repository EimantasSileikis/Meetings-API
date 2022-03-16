using System.ComponentModel.DataAnnotations;

namespace Meetings_API.Models
{
    public class Meeting
    {
        public Guid Id { get; init; }
        [Required]
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();

    }
}
