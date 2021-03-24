namespace Gallery.DataModels
{
    using Gallery.Enums;

    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ItemType Type { get; set; }
        public decimal Price { get; set; }
    }
}
