

using System.ComponentModel.DataAnnotations;

namespace TheWorld.ViewModels
{
    public class ContactVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength (4000,MinimumLength =10)]
        public string Message { get; set; }
    }
}