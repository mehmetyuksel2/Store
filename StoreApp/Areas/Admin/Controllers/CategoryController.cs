using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]//bu sayfayý görebilmek için login olmak yeterli
    [Authorize(Roles="Admin")]//hem login olup hemde bu admin ise bu sayfayý gör
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}