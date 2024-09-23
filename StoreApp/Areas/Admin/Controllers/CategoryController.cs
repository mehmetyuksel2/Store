using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]//bu sayfay� g�rebilmek i�in login olmak yeterli
    [Authorize(Roles="Admin")]//hem login olup hemde bu admin ise bu sayfay� g�r
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}