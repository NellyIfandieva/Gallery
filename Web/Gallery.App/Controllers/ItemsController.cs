namespace Gallery.App.Controllers
{
    using Gallery.Enums;
    using Gallery.Services.Contracts;
    using Gallery.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class ItemsController : Controller
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        public async Task<IActionResult> AllGifts()
        {
            var allGiftItemsInDb = await this.itemService
                .DisplayAllItemsAsync(CommercialType.Gift);

            var allGiftsToDisplay = allGiftItemsInDb
                .Select(i => new ItemListingVM
                {
                    Id = i.Id,
                    Title = i.Title,
                    Type = i.Type,
                    CommercialType = i.CommercialType,
                    Size = i.Size,
                    Price = i.Price,
                    Images = i.Images
                    .Select(im => new ImageVM
                    {
                        Id = im.Id,
                        Url = im.Url,
                        ItemId = i.Id
                    }).ToList()
                });

            return View(allGiftsToDisplay);
        }

        public async Task<IActionResult> AllPersonal()
        {
            var allPersonalItemsInDb = await this.itemService
                .DisplayAllItemsAsync(CommercialType.Personal);

            var allPersonalToDisplay = allPersonalItemsInDb
                .Select(i => new ItemListingVM
                {
                    Id = i.Id,
                    Title = i.Title,
                    Type = i.Type,
                    CommercialType = i.CommercialType,
                    Size = i.Size,
                    Price = i.Price,
                    Images = i.Images
                    .Select(im => new ImageVM
                    {
                        Id = im.Id,
                        Url = im.Url,
                        ItemId = i.Id
                    }).ToList()
                });

            return View(allPersonalToDisplay);
        }

        public async Task<IActionResult> AllForSale()
        {
            var allForSaleInDb = await this.itemService
                .DisplayAllItemsAsync(CommercialType.ForSale);

            var allForSaleDisplay = allForSaleInDb
                .Select(i => new ItemListingVM
                {
                    Id = i.Id,
                    Title = i.Title,
                    Type = i.Type,
                    CommercialType = i.CommercialType,
                    Size = i.Size,
                    Price = i.Price,
                    Images = i.Images
                    .Select(im => new ImageVM
                    {
                        Id = im.Id,
                        Url = im.Url,
                        ItemId = i.Id
                    }).ToList()
                });

            return View(allForSaleDisplay);
        }

        [HttpGet("Items/Details/itemId")]
        public async Task<IActionResult> Details(int itemId)
        {
            if(itemId <= 0)
            {
                return BadRequest();
            }

            var itemInDb = await this.itemService
                .GetByIdAsync(itemId);

            var detailsVM = new ItemDetailsVM
            {
                Id = itemInDb.Id,
                Title = itemInDb.Title,
                Description = itemInDb.Description,
                Type = itemInDb.Type,
                CommercialType = itemInDb.CommercialType,
                Size = itemInDb.Size,
                Price = itemInDb.Price,
                Quantity = itemInDb.Quantity,
                Images = itemInDb.Images
                .Select(im => new ImageVM
                { 
                    Id = im.Id,
                    Url = im.Url,
                    ItemId = itemInDb.Id
                }).ToList(),
                IsAvailable = itemInDb.IsAvailable
            };

            return View(detailsVM);
        }
    }
}
