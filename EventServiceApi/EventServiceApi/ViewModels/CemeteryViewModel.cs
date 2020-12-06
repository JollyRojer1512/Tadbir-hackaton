using System.ComponentModel.DataAnnotations;

namespace EventServiceApi.ViewModels
{
    public class CemeteryViewModel
    {
        public long CemeteryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CemeteryName { get; set; }

        [Required]
        [MaxLength(50)]
        public string CemeteryRequiredPhoneNumber { get; set; }

        [MaxLength(50)]
        public string CemeteryAdditionalPhoneNumber { get; set; }

        [Required]
        public string CemeteryCity { get; set; }

        public string CemeteryDistrict { get; set; }
    }
}