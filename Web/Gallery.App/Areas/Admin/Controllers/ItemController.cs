using Gallery.InputModels;
using Gallery.ServiceModels;
using Gallery.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallery.App.Areas.Admin.Controllers
{
    public class ItemController : AdminController
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            return View(new ItemCreateIM());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ItemCreateIM model)
        {
            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            var createSM = new ItemCreateSM
            {
                Title = model.Title,
                Description = model.Description,
                Type = model.Type,
                CommercialType = model.CommercialType,
                Price = model.Price,
                Size = model.Size,
                Quantity = model.Quantity,
                // ImageUrls
            };

            var createResult = await this.itemService.CreateAsync(createSM);

            if(createResult == null)
            {

            }

            return RedirectToAction("ViewAll");
        }
    }
}
