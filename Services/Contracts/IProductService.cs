using Entities.Dtos;
using Entities.Models;
using Entities.RequestParam;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        IEnumerable<Product> GetLastestProducts(int n,bool trackChanges);
        IEnumerable<Product> GetShowCaseProducts(bool trackChanges);
        IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateProduct(ProductDtoForInsertion productDto);
        void UpdateOneProduct(ProductDtoForUpdate product);
        void DeleteOneProduct(int id);//productControllerde kullanılması için burada arayüz tanımı gerçekleştiriliyor --> bunu takip et
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
    }
}