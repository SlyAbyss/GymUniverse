using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymUniverse.Constants.DataModelConstants;

namespace GymUniverse.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ContactMessageNameMaxLength, MinimumLength = ContactMessageNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(ContactMessageEmailMaxLength, MinimumLength = ContactMessageEmailMinLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(ContactMessageMessageMaxLength, MinimumLength = ContactMessageMessageMinLength)]
        public string Message { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}
