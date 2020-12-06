using System.ComponentModel.DataAnnotations;

namespace EventApi.ViewModels
{
    public class CompanyViewModel
    {
        public long CompanyId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [RegularExpression(@"^\d{9}$")]
        public string CompanyInn { get; set; }

        [Required]
        public string CompanyPhone { get; set; }

        public string CompanyEmail { get; set; }

        public string CompanyWebsite { get; set; }
    }
}