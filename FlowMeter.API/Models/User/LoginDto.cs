using System.Text.Json.Serialization;

namespace FlowMeter.API.Models.User
{
    public class LoginDto
    {
        public string Email { get; set; }
        
        public string Password { get; set; }   
    }
}
