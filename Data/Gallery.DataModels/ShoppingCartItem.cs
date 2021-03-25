namespace Gallery.DataModels
{
    public class ShoppingCartItem : BaseModel<int>
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }

        public string ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
