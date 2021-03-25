namespace Gallery.DataModels
{
    public class ItemImage : BaseModel<int>
    {
        public string Url { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
