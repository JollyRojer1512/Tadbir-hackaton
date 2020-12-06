using System.ComponentModel.DataAnnotations;
using EventServiceApi.ViewModels;

namespace EventServiceApi.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public UserViewModel ConvertToViewModel()
        {
            return new UserViewModel()
            {
                UserId = Id,
                Username = Username,
                UserFirstName = FirstName,
                UserLastName = LastName,
                UserPhoneNumber = PhoneNumber,
                UserEmail = Email
            };
        }
    }
}