namespace Gallery.DataModels
{
    using System.Collections.Generic;

    public class ShoppingCart : BaseModel<string>
    {
        public string UserId { get; set; }
        public GalleryUser User { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = 
            new List<ShoppingCartItem>();
    }
}
