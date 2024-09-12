using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Product
{
        public int ProductId { get; set; }
        public String? ProductName { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public String? Summary { get; set; } = String.Empty;
        public String? ImageUrl { get; set; }
        public int? CategoryId { get; set; }//Foregein Key
        //burdada newlemenin aksine daha önce oluşturulmuş category yi id ile
        //ilişkilendiriyoruz
        //AutoMapper
        public Category? Category { get; set; }//Navigation Property
                                               //ürün eklerken new category olarak yeni kategori ekleyebiliyoruz
        public bool ShowCase { get; set; }
}
