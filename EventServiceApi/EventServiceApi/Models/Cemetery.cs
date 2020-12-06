using EventServiceApi.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EventServiceApi.Models
{
    public class Cemetery
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string RequiredPhoneNumber { get; set; }

        [MaxLength(50)]
        public string AdditionalPhoneNumber { get; set; }

        [Required]
        public string City { get; set; }

        public string District { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public CemeteryViewModel ConvertToViewModel()
        {
            return new CemeteryViewModel()
            {
                CemeteryId = Id,
                CemeteryName = Name,
                CemeteryRequiredPhoneNumber = RequiredPhoneNumber,
                CemeteryAdditionalPhoneNumber = AdditionalPhoneNumber,
                CemeteryCity = City,
                CemeteryDistrict = District
            };
        }
    }
}