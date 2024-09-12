using Entities.Models;
using Entities.RequestParam;

namespace Repositories.Contracts 
{//buradaki metodlar ise product a özel yazılır
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        IQueryable<Product> GetShowCaseProducts(bool trackChanges);
        IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateOneProduct(Product product);
        void DeleteOneProduct(Product product);//ProductManagerde kullanılması için burada arayüz tanımı yapıyoruz --> bunu takip et
        void UpdateOneProduct(Product entity);
    }

}