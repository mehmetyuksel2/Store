using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]//Hangi alanda çalışacağına dair bilgi verilir
    //[Authorize]//bu sayfayı görebilmek için login olmak yeterli
    [Authorize(Roles = "Admin")]//hem login olup hemde bu admin ise bu sayfayı gör
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var orders = _manager.OrderService.Orders;
            return View(orders);
        }
        [HttpPost]
        public IActionResult Complete([FromForm] int id)
        {
            _manager.OrderService.Complete(id);
            return RedirectToAction("Index");
        }
    }
}
