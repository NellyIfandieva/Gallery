namespace Gallery.DataModels
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GalleryUser : IdentityUser
    {
        private const string RequiredErrorMessage = "The field is required.";

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
