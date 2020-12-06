using EventServiceApi.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EventServiceApi.Models
{
    public class WasherDead
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


        public WasherDeadViewModel ConvertToViewModel()
        {
            return new WasherDeadViewModel()
            {
                WasherDeadId = Id,
                WasherDeadFirstName = FirstName,
                WasherDeadLastName = LastName,
                WasherDeadRequiredPhoneNumber = RequiredPhoneNumber,
                WasherDeadAdditionalPhoneNumber = AdditionalPhoneNumber,
                WasherDeadCity = City,
                WasherDeadDistrict = District
            };
        }
    }
}