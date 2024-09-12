using Microsoft.AspNetCore.Mvc;
namespace StoreApp.Areas.Admin.Controllers
{   [Area("Admin")]
    public class DashboardController : Controller
    {
                    //arealar asp.net core projesi içerisindeki bir alan
                    // bu alan kendi başına bir mini proje gibi işlev görür
                    //program.cs de route ayarları yapıldı. area lara özel
                    //dosya açıldı ve bir mvc projesi gibi dosyalama sistemi
                    //yapıldı.
        public IActionResult Index()
        {
            return View();
        }
    }
}