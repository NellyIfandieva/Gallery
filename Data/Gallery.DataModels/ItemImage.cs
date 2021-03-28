using System.ComponentModel.DataAnnotations;

namespace Gallery.DataModels
{
    public class ItemImage : BaseModel<int>
    {
        [Required(ErrorMessage = "The Url Is Required.")]
        public string Url { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
