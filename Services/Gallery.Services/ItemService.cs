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
                Price = model.Price,
                Quantity = model.Quantity
            };

            this.db.Items.Add(item);
            int? result = await db.SaveChangesAsync();

            if(result == null)
            {
                return result;
            }

            item.Images = await CreateImages(model.ImageUrls, item);
            result = await db.SaveChangesAsync();

            if (result == null)
            {
                return result;
            }

            return item.Id;
        }

        public async Task<IEnumerable<ItemSM>> DisplayAllItemsAsync(CommercialType? commercialType)
        {
            if(commercialType == null)
            {
                return await this.db
                .Items
                .Include(i => i.Images)
                .Select(i => new ItemSM
                {
                    Id = i.Id,
                    Type = i.Type,
                    Title = i.Title,
                    Images = i.Images
                    .Select(im => new ImageSM
                    {
                        Id = im.Id,
                        Url = im.Url,
                        ItemId = im.ItemId
                    }).ToList(),
                    CommercialType = i.CommercialType,
                    Size = i.Size,
                    Price = i.Price
                })
                .ToListAsync();
            }

            return await this.db
                .Items
                .Where(i => i.CommercialType == commercialType)
                .Include(i => i.Images)
                .Select(i => new ItemSM
                {
                    Id = i.Id,
                    Type = i.Type,
                    Title = i.Title,
                    Images = i.Images
                    .Select(im => new ImageSM
                    {
                        Id = im.Id,
                        Url = im.Url,
                        ItemId = im.ItemId
                    }).ToList(),
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

        private async Task<List<ItemImage>> CreateImages(List<string> imageUrls, Item item)
        {
            var images = new List<ItemImage>();

            foreach (var url in imageUrls)
            {
                images.Add(new ItemImage
                {
                    Url = url,
                    ItemId = item.Id,
                    Item = item
                });
            }

            this.db.ItemImages.AddRange(images);
            int? result = await db.SaveChangesAsync();

            if (result == null)
            {
                return null;
            }

            return images;
        }

        //private void AddMainPicture(Item item, ItemImage image)
        //{
        //    item.ImageUrls.Add(image);
        //}
    }
}
