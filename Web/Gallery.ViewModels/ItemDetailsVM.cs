using Gallery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.ViewModels
{
    public class ItemDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<ImageVM> Images { get; set; } = new List<ImageVM>();

        public ItemType Type { get; set; }
        public CommercialType CommercialType { get; set; }

        public Sizing Size { get; set; }

        public decimal Price { get; set; }

        public byte Quantity { get; set; }

        public bool IsAvailable { get; set; }
    }
}
