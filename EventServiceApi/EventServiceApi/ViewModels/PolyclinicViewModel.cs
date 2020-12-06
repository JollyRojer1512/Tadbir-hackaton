using System.ComponentModel.DataAnnotations;

namespace EventServiceApi.ViewModels
{
    public class PolyclinicViewModel
    {
        public long PolyclinicId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PolyclinicName { get; set; }

        [Required]
        [MaxLength(50)]
        public string RequiredPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string AdditionalPhoneNumber { get; set; }

        [Required]
        public string PolyclinicCity { get; set; }

        public string PolyclinicDistrict { get; set; }
    }
}