namespace Gallery.Services
{
    using Data;
    using DataModels;
    using Gallery.Enums;
    using Gallery.ServiceModels;
    using Microsoft.EntityFrameworkCore;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ItemService : IItemService
    {
        private readonly GalleryDbContext db;

        public ItemService(GalleryDbContext db)
        {
            this.db = db;
        }

        public async Task<int?> CreateAsync(ItemCreateSM model)
        {
            var item = new Item
            {
                Type = model.Type,
                Title = model.Title,
                Description = model.Description,
                Size = model.Size,
              //  ImageUrls = model.ImageUrls,
                Price = model.Price,
                Quantity = model.Quantity
            };

            this.db.Items.Add(item);
            int? result = await db.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<ItemSM>> DisplayAllItemsAsync(CommercialType? commercialType)
        {
            if(commercialType == null)
            {
                return await this.db
                .Items
                .Select(i => new ItemSM
                {
                    Id = i.Id,
                    Type = i.Type,
                    Title = i.Title,
                    Size = i.Size,
                    Price = i.Price
                })
                .ToListAsync();
            }

            return await this.db
                .Items
                .Where(i => i.CommercialType == commercialType)
                .Select(i => new ItemSM
                {
                    Id = i.Id,
                    Type = i.Type,
                    Title = i.Title,
                    Size = i.Size,
                    Price = i.Price
                })
                .ToListAsync();
        }

        public async Task<ItemDetailsSM> GetByIdAsync(int itemId)
        {
            var itemInDb = await this.db
                .Items
                .Select(i => new ItemDetailsSM
                {
                    
                })
                .SingleOrDefaultAsync(i => i.Id == itemId);
            return null;
        }

        private void AddMainPicture(Item item, ItemImage image)
        {
            item.ImageUrls.Add(image);
        }
    }
}
