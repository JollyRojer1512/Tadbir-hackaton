using EventApi.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EventApi.Models
{
    public class Polyclinic
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

        public PolyclinicViewModel ConvertToViewModel()
        {
            PolyclinicViewModel viewModel = new PolyclinicViewModel()
            {
                PolyclinicId = Id,
                PolyclinicName = Name,
                RequiredPhoneNumber = RequiredPhoneNumber,
                AdditionalPhoneNumber = AdditionalPhoneNumber,
                PolyclinicCity = City,
                PolyclinicDistrict = District
            };

            return viewModel;
        }

    }
}