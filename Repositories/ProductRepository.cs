using Entities.Models;
using Entities.RequestParam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository//bir üst base classları kullanabilmek için
                                                                            //söz konusu classlardan türetiyoruz
    {
        public ProductRepository(RepositoryContext context) : base(context)//RepositoryBase sınıfından implemente etmek zorunda olduğumuz
                                                                        //için boş bir şekilde implemente ediyoruz
        {
        }

        public void DeleteOneProduct(Product product) => Remove(product);//ProductManager de kullanılması için burada implemente ediyoruz --> removu takip et

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);//burada tanımladığımız metodumuzun altında

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)//bu metod ProductManager dan çağırılır--parametresinde çağırılan değer
                                                                                        //categoryId ve searchTerm dir
        {
            return _context.Products
                .FilterByCategoryId(p.CategoryId)
                .FilteredBySearchTerm(p.SearchTerm)
                .FilteredByPrice(p.MinPrice,p.MaxPrice,p.IsValidPrice);
                
        }

        //findall metodunu çağırıyoruz.
        public Product? GetOneProduct(int id, bool trackChanges)
       {
            return FindByCondition(p=>p.ProductId.Equals(id),trackChanges);
       }

        public IQueryable<Product> GetShowCaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(p => p.ShowCase.Equals(true));
        }

        public void UpdateOneProduct(Product entity) => Update(entity);

        void IProductRepository.CreateOneProduct(Product product) => Create(product);
    
    }
}