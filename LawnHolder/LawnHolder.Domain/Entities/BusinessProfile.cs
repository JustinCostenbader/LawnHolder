using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnHolder.Domain.Entities
{
    public class BusinessProfile
    {
        [Key]
        public string BusinessId { get; set; }
        
        [Required]
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Serviced Areas")]
        public string ServicedAreas { get; set; }

        public string Description { get; set; }

    }
}
