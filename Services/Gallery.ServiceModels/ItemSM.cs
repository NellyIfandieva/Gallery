using Gallery.Enums;

namespace Gallery.ServiceModels
{
    public class ItemSM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ItemType Type { get; set; }
        public decimal Price { get; set; }
    }
}
