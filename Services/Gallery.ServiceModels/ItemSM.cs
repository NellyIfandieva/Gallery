namespace Gallery.ServiceModels
{
    using Gallery.Enums;
    using System.Collections.Generic;

    public class ItemSM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ImageSM> Images { get; set; }
        public ItemType Type { get; set; }
        public CommercialType CommercialType { get; set; }
        public Sizing Size { get; set; }
        public decimal Price { get; set; }
    }
}
