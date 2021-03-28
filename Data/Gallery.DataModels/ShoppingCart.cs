namespace Gallery.DataModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ShoppingCart : BaseModel<string>
    {
        [Required(ErrorMessage = "The User Id Is Required.")]
        public string UserId { get; set; }
        public GalleryUser User { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = 
            new List<ShoppingCartItem>();
    }
}
