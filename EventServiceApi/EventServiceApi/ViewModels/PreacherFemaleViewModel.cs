using System.ComponentModel.DataAnnotations;

namespace EventServiceApi.ViewModels
{
    public class PreacherFemaleViewModel
    {
        public long PreacherId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PreacherFirstName { get; set; }

        [MaxLength(50)]
        public string PreacherLastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string PreacherRequiredPhoneNumber { get; set; }

        [MaxLength(50)]
        public string PreacherAdditionalPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string PreacherCity { get; set; }

        [MaxLength(50)]
        public string PreacherDistrict { get; set; }
    }
}