using System.ComponentModel.DataAnnotations;
using EventServiceApi.ViewModels;

namespace EventServiceApi.Models
{
    public class Transport
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string StateNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string DriverFirstName { get; set; }

        [MaxLength(50)]
        public string DriverLastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string DriverRequiredPhoneNumber { get; set; }

        [MaxLength(50)]
        public string DriverAdditionalPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string District { get; set; }

        public TransportViewModel ConvertToViewModel()
        {
            TransportViewModel viewModel = new TransportViewModel()
            {
                TransportId = Id,
                TransportStateNumber = StateNumber,
                DriverFirstName = DriverFirstName,
                DriverLastName = DriverLastName,
                DriverRequiredPhoneNumber = DriverRequiredPhoneNumber,
                DriverAdditionalPhoneNumber = DriverAdditionalPhoneNumber,
                TransportCity = City,
                TransportDistrict = District
            };

            return viewModel;
        }

    }
}