using System.ComponentModel.DataAnnotations;

namespace EventServiceApi.ViewModels
{
    public class TransportViewModel
    {
        public long TransportId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TransportStateNumber { get; set; }

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
        public string TransportCity { get; set; }

        public string TransportDistrict { get; set; }
    }
}