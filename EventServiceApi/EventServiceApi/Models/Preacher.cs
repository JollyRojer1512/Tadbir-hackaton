using EventApi.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EventApi.Models
{
    public class Preacher
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string RequiredPhoneNumber { get; set; }

        [MaxLength(50)]
        public string AdditionalPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string District { get; set; }


        public PreacherViewModel ConvertToViewModel()
        {
            return new PreacherViewModel()
            {
                PreacherId = Id,
                PreacherFirstName = FirstName,
                PreacherLastName = LastName,
                PreacherRequiredPhoneNumber = RequiredPhoneNumber,
                PreacherAdditionalPhoneNumber = AdditionalPhoneNumber,
                PreacherCity = City,
                PreacherDistrict = District
            };
        }

    }
}