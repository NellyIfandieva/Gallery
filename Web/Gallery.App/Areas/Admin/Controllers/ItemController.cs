namespace Gallery.App.Areas.Admin.Controllers
{
    using Gallery.Enums;
    using Gallery.InputModels;
    using Gallery.ServiceModels;
    using Gallery.Services.Contracts;
    using Gallery.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ItemController : AdminController
    {
        private readonly IItemService itemService;
        private readonly ICloudinaryService cloudinaryService;

        public ItemController(
            IItemService itemService,
            ICloudinaryService cloudinaryService)
        {
            this.itemService = itemService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet("/Admin/Item/Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("/Admin/Item/Create")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ItemCreateIM model)
        {
            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            ItemType itemType;
            bool isValidType = Enum.TryParse<ItemType>(model.Type, out itemType);

            CommercialType itemCommType;
            bool isValidCommercialType = Enum.TryParse<CommercialType>(model.CommercialType, out itemCommType);

            Sizing size;
            bool isValidSize = Enum.TryParse<Sizing>(model.Size, out size);

            if (isValidCommercialType == false ||
                isValidType == false ||
                isValidSize == false)
            {
                var error = new ErrorVM
                {
                    Message = "Please, insert Personal, Gift or ForSale as Commercial Type"
                };

                return RedirectToAction("Error", error);
            }

            var createSM = new ItemCreateSM
            {
                Title = model.Title,
                Description = model.Description,
                Type = itemType,
                CommercialType = itemCommType,
                Size = size,
                Price = model.Price,
                Quantity = model.Quantity
            };

            createSM.ImageUrls = await UploadImages((List<IFormFile>)model.Images, model.Title);

            var createResult = await this.itemService.CreateAsync(createSM);

            if(createResult == null)
            {
                var error = new ErrorVM
                {
                    Message = "The item was not properly added to the Database."
                };

                return RedirectToAction("Error", error);
            }

            return Redirect("/");
        }

        public IActionResult Error(ErrorVM error)
        {
            return View(error);
        }

        private async Task<List<string>> UploadImages(List<IFormFile> images, string title)
        {
            var imageUrls = new List<string>();

            for(int i = 0; i < images.Count; i++)
            {
                IFormFile file = images[i];
                imageUrls.Add(await this.cloudinaryService.UploadEntityIllustrationAsync(file, $"{title}_{i + 1}"));
            }

            return imageUrls;
        }
    }
}
