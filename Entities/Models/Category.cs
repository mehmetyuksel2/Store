namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        //örneğin 1 numaralı category product tarafında defalarca kullanılabilir
        public string? CategoryName { get; set; } = String.Empty;
        public ICollection<Product> Product { get; set; } //Collection Navigation Property
        //AutoMapper
    }
}