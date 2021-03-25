namespace Gallery.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AboutController : Controller
    {
        public IActionResult Me()
        {
            return View();
        }
    }
}
