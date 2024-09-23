using System.Runtime.CompilerServices;

namespace Entities.Models
{
    public class Cart
    {//razor pages de controller sız kullanmak için örneklendirmeler burada mevcut.
     //pagemodel örneklendirmeleri
        public List<CartLine> Lines { get; set; }//sepetteki satırları ifade eder.
        
        public Cart()
        {
            Lines = new List<CartLine>();
        }
        public virtual void AddItem(Product product, int quantity)//bu metod cart.cshtml.cs tarafından çağırılır
        {
            CartLine? line = Lines.Where(l => l.Product.ProductId.Equals(product.ProductId))
            .FirstOrDefault();//gönderilen ürün carta yani lines da varsa adet arttırılır yoksa eklenir

            if (line is null)
            {
                Lines.Add(new CartLine(){
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Product product)=>
            Lines.RemoveAll(l => l.Product.ProductId.Equals(product.ProductId));

        public decimal ComputeTotalValue()=>
            Lines.Sum(e => e.Product.Price * e.Quantity);

            public virtual void Clear() => Lines.Clear();
        
    }
}