using System.ComponentModel.DataAnnotations;

namespace LawnHolder.Web.Areas.Identity.Models.ManageViewModels
{
    public class UpdateBusinessInfoViewModel
    {
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Serviced Areas")]
        public string ServicedAreas { get; set; }

        public string Description { get; set; }

        public string StatusMessage { get; set; }
    }
}
