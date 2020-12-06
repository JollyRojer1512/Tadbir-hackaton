using System.ComponentModel.DataAnnotations;

namespace EventServiceApi.ViewModels
{
    public class UserViewModel
    {
        public long UserId { get; set; }

        [Required]
        public string Username { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        [Required]
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
    }
}