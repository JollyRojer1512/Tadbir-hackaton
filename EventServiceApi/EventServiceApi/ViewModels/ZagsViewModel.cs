using System.ComponentModel.DataAnnotations;

namespace EventServiceApi.ViewModels
{
    public class ZagsViewModel
    {
        public long ZagsId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ZagsName { get; set; }

        [Required]
        [MaxLength(50)]
        public string ZagsRequiredPhoneNumber { get; set; }

        [MaxLength(50)]
        public string ZagsAdditionalPhoneNumber { get; set; }

        [Required]
        public string ZagsCity { get; set; }

        public string ZagsDistrict { get; set; }
    }
}