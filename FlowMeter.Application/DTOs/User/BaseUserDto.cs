using System.ComponentModel.DataAnnotations;

namespace FlowMeter.Application.DTOs.User
{
    public class BaseUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
