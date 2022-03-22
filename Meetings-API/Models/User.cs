using System.ComponentModel.DataAnnotations;

namespace Meetings_API.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
