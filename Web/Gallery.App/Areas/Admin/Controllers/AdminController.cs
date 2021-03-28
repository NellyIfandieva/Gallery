namespace Gallery.App.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Admin, ADMIN")]
    [Area("Admin")]
    public abstract class AdminController : Controller
    {
    }
}
