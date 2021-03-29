namespace Gallery.DataModels
{
    using Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Item : BaseModel<int>
    {
        private const string MinPrice = "0.00";
        private const string MaxPrice = "10000";
        private const string RequiredErrorMessage = "The field is required.";

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Title { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Description { get; set; }

        public List<ItemImage> Images { get; set; } = new List<ItemImage>();

        public ItemType Type { get; set; }

        public CommercialType CommercialType { get; set; }

        public Sizing Size { get; set; }

        [Range(typeof(decimal), MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        public byte Quantity { get; set; }

        public bool IsAvailable { get; set; }

        public string OrderId { get; set; }
        public Order Order { get; set; }

        public string ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
