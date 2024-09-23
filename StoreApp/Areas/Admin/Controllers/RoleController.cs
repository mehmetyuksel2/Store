using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]//bu sayfayı görebilmek için login olmak yeterli
    [Authorize(Roles = "Admin")]//hem login olup hemde bu admin ise bu sayfayı gör
    public class RoleController : Controller
    {
        private readonly IServiceManager _manager;

        public RoleController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.AuthService.Roles);
        }
        public IActionResult DeleteRole([FromForm(Name ="id")] string id )
        {
            _manager.AuthService.DeleteRole(id);
            return RedirectToAction("Index");
        }
    }
}
