using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.infrastructure.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        public Cart Cart { get; set; }

        public CartModel(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            Cart = cart;
        }

        public string ReturnUrl { get; set; }="/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetOneProduct(productId,false);//sepete eklenen �r�n varsa de�i�kene atan�r
            if(product is not null)
            {
                Cart.AddItem(product,1);//�r�n varsa cart addItem ile sepete at�l�r
            }
            return RedirectToPage(new { returnUrl = returnUrl }); //returnUrl
        }
        public IActionResult OnPostRemove(int Id, string returnUrl)//cart pagesinden remove formundan gelen verilerle silme i�lemi yap�l�r
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(Id)).Product);
            return Page();
        }
    }
}