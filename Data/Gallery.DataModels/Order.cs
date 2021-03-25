namespace Gallery.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order : BaseModel<string>
    {

        [Display(Name = "Issued On")]
        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }
        public GalleryUser User { get; set; }

        public List<OrderedProduct> OrderedProducts { get; set; } = new List<OrderedProduct>();
    }
}
