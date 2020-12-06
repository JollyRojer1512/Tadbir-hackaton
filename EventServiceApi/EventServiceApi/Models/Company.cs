using EventApi.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EventApi.Models
{
    public class Company
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{9}$")]
        public string Inn { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public CompanyViewModel ConvertToViewModel()
        {
            return new CompanyViewModel()
            {
                CompanyId = Id,
                CompanyInn = Inn,
                CompanyName = Name,
                CompanyPhone = Phone,
                CompanyEmail = Email,
                CompanyWebsite = Website
            };
        }
    }
}