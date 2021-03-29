namespace Gallery.ViewModels
{
    using Gallery.Enums;
    using System.Collections.Generic;

    public class ItemListingVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ImageVM> Images { get; set; }
        public ItemType Type { get; set; }
        public CommercialType CommercialType { get; set; }
        public Sizing Size { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable => this.Quantity > 0;
    }
}
