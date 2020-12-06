using EventServiceApi.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EventServiceApi.Models
{
    public class Zags
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

        public ZagsViewModel ConvertToViewModel()
        {
            return new ZagsViewModel()
            {
                ZagsId = Id,
                ZagsName = Name,
                ZagsRequiredPhoneNumber = RequiredPhoneNumber,
                ZagsAdditionalPhoneNumber = AdditionalPhoneNumber,
                ZagsCity = City,
                ZagsDistrict = District
            };
        }
    }
}