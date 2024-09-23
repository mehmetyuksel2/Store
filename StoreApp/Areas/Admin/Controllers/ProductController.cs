using Entities.Dtos;
using Entities.Models;
using Entities.RequestParam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Extensions;
using Services.Contracts;
using StoreApp.Models;
namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]//bu sayfayı görebilmek için login olmak yeterli
    [Authorize(Roles = "Admin")]//hem login olup hemde bu admin ise bu sayfayı gör
    public class ProductController : Controller
    {

        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index([FromQuery] ProductRequestParameters p)
        {
            ViewData["Title"] = "Products";
            var products = _manager.ProductService.GetAllProductsWithDetails(p);//bütün verileri çek
            var pagination = new Pagination()//gelen verileri paginaton nesnesiyle eşleştir
            {
                CurrenPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()//model olarak paketleyip gönder
            {
                Products = products,
                Pagination = pagination

            });//ve view a gönder
        }
        public IActionResult Create()
        {
            //ViewBag.Categories = _manager.CategoryService.GetAllCategories(false);
            //viewbag ile gönderilen bu veri foreach ile listelenebilir.

            ViewBag.Categories = GetCategoriesSelectList();
            //create sayfasına viewbag ile category bilgisi gönderilir.
            //bu şekilde foreach siz kullanım olur
            return View();
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false),
            "CategoryId","CategoryName","1");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot","images",file.FileName);
                using(var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images/",file.FileName);

                _manager.ProductService.CreateProduct(productDto);
                TempData["success"] = $"{productDto.ProductName} has been created.";//eklenen ürünün ismini yazdır
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetOneProductForUpdate(id,false);
            ViewData["Title"] = model.ProductName;//title a productName verir
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                // file operation 
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot","images", file.FileName);// tümüyle bir path oluşturduk
                using(var stream = new FileStream(path,FileMode.Create))
                //maliyetli işlemler burada yapılabilir. bunun sonuna gelingiğinde kullanılan
                // tüm kaynaklar serbest bırakılır. 
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images/", file.FileName);
                _manager.ProductService.UpdateOneProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);//productManager'de implemente edilmiş metodu burada kullanıyoruz --> bunu takip et
            TempData["danger"] = "The product has been removed.";//_Notificated
            return RedirectToAction("Index");
        }
    }
} 