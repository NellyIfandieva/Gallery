namespace Gallery.DataModels
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GalleryUser : IdentityUser
    {
        private const string RequiredErrorMessage = "The field is required.";

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Deliver Address")]
        public string DeliveryAddress { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
