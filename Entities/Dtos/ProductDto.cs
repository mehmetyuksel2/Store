using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{//Dto Data Transfer Object // ummutable olduğu için bir kez oluşturulurken değer atanır.
 //Sonrasında değiştirilemezler
    public record ProductDto
    {
        public int ProductId { get; init; }
        [Required(ErrorMessage ="ProductName is required")]
        public String? ProductName { get; init; } = String.Empty;
        [Required(ErrorMessage ="Price is required")]
        public decimal Price { get; init; }
        public String? Summary { get; init; } = String.Empty;
        public String? ImageUrl { get; set; }
        public int? CategoryId { get; init; }
        
    }
}