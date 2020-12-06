using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventApi.ViewModels
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