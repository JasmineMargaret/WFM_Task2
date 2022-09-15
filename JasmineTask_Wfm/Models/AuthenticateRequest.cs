using System.ComponentModel.DataAnnotations;
namespace JasmineTask_Wfm.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
