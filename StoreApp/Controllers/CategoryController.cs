using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private IRepositoryManager _manager;//repository manager nesnesini injection ediyoruz. bu dosyada kullanıyoruz

        public CategoryController(IRepositoryManager manager)
        {
            _manager = manager;//Injection işleminin devamı
        }
        public IActionResult Index()
        {
            var model = _manager.Category.FindAll(false);//repositorybase deki metodun kullanılması. buradan
            return View(model);
        }
    }
}