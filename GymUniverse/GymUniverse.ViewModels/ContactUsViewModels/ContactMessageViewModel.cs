using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymUniverse.Constants.DataModelConstants;

namespace GymUniverse.ViewModels.ContactUsViewModels
{
    public class ContactMessageViewModel
    {
        [Required]
        [StringLength(ContactMessageNameMaxLength, MinimumLength = ContactMessageNameMinLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(ContactMessageEmailMaxLength, MinimumLength = ContactMessageEmailMinLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(ContactMessageMessageMaxLength, MinimumLength = ContactMessageMessageMinLength)]
        public string Message { get; set; }

        public string? LoggedInUsername { get; set; }
        public string? LoggedInEmail { get; set; }
    }
}
