using System.ComponentModel.DataAnnotations;

namespace EventServiceApi.ViewModels
{
    public class WasherDeadViewModel
    {
        public long WasherDeadId { get; set; }

        [Required]
        [MaxLength(50)]
        public string WasherDeadFirstName { get; set; }

        [MaxLength(50)]
        public string WasherDeadLastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string WasherDeadRequiredPhoneNumber { get; set; }

        [MaxLength(50)]
        public string WasherDeadAdditionalPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string WasherDeadCity { get; set; }

        [MaxLength(50)]
        public string WasherDeadDistrict { get; set; }
    }
}