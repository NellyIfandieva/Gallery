using Gallery.App.Models;
using Gallery.Services.Contracts;
using Gallery.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gallery.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemService itemService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IItemService itemService,
            ILogger<HomeController> logger)
        {
            this.itemService = itemService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allItemsInDb = await this.itemService
                .DisplayAllItemsAsync(null);

            var allItemsToDisplay = allItemsInDb
                .Select(i => new ItemListingVM
                { 
                    Id = i.Id,
                    Title = i.Title,
                    Images = i.Images
                    .Select(im => new ImageVM
                    {
                       Id = im.Id,
                       Url = im.Url,
                       ItemId = im.ItemId
                    }).ToList(),
                    Type = i.Type,
                    CommercialType = i.CommercialType,
                    Size = i.Size,
                    Price = i.Price
                });

            return View("Index1");

            //return View(allItemsToDisplay);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
