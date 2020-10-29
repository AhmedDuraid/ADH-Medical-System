using System.ComponentModel.DataAnnotations;

namespace ADHUIServer.Models
{
    public class LoginModle
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
