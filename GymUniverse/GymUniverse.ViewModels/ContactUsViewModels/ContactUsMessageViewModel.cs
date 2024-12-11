using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymUniverse.Constants.DataModelConstants; 

namespace GymUniverse.ViewModels.ContactUsViewModels
{
    public class ContactFormViewModel
    {
        [Required]
        [StringLength(ContactMessageNameMaxLength, MinimumLength = ContactMessageNameMinLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(ContactMessageEmailMaxLength, MinimumLength = ContactMessageEmailMinLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(ContactMessageMessageMaxLength, MinimumLength = ContactMessageMessageMinLength)]
        public string Message { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}
