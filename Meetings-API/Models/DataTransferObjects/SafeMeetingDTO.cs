using System.ComponentModel.DataAnnotations;

namespace Meetings_API.Models.DataTransferObjects
{
    public class MeetingDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
