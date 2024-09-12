using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Entities.RequestParam;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        //dependecy injection patterni repository i dosyasını enjeksiyon diyoruz
        //tekrar tekrar _manager bağlantısını yapmak zorunda kalmıyoruz

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
            var model = _manager.ProductService.GetAllProductsWithDetails(p);//bütün verileri çek
            return View(model);//ve view a gönder
        }
        public IActionResult Get([FromRoute(Name="id")]int id){//fromRoute id nin nereden geleceğini belirtir Route tan geliyor
            //Product product = _context.Products.First(p => p.ProductId.Equals(id));
            var model = _manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }
    }
}