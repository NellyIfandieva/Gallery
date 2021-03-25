using Gallery.Enums;
using System;

namespace Gallery.ViewModels
{
    public class ItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ItemType Type { get; set; }
        public CommercialType CommercialType { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}
