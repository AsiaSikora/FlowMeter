using System.ComponentModel.DataAnnotations;

namespace FlowMeter.Application.DTOs.User
{
    public class CreateUserDto : BaseUserDto
    {
        [Required]
        public string Password { get; set; }
    }
}
