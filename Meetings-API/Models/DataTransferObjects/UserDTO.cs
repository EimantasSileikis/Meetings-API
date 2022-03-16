using System.ComponentModel.DataAnnotations;

namespace Meetings_API.Models.DataTransferObjects
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
