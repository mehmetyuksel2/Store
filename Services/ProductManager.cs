using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParam;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            // Product product = new Product()
            // {
            //     ProductName = productDto.ProductName,
            //     Price       = productDto.Price,
            //     CategoryId  = productDto.CategoryId
            // };
            //infrastructe dosyası, yani auto mapper olmasaydı map işlemini bu şekilde yapıyorduk. ^
            Product product = _mapper.Map<Product>(productDto);
            //automapper örnek eşleştirmesi

            _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)//productControllerde kullanılmak için burada implemente ediyoruz
        {
            Product product=GetOneProduct(id,false);
            if(product is not null)
            {
                _manager.Product.DeleteOneProduct(product);// --> bunu takip et
                _manager.Save();
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _manager.Product.GetAllProductsWithDetails(p);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id,trackChanges);
            if(product is null){
                throw new Exception("Product Not Found!");
            }
            return product;
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = GetOneProduct(id,trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);

            //product nesnesi ProductDtoForUpdate nesnesine çevirilerek
            //productDto nesnesine aktarıldı ve return olarak gönderildi.
            return productDto;
        }

        public IEnumerable<Product> GetShowCaseProducts(bool trackChanges)
        {
            var products = _manager.Product.GetShowCaseProducts(trackChanges);
            return products;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            // var entity = _manager.Product.GetOneProduct(productDto.ProductId,true);
        
            // if (entity == null)
            // {
            //     throw new InvalidOperationException("Product not found.");
            // }
            // entity.ProductName = productDto.ProductName;
            // entity.Price = productDto.Price;
            // entity.CategoryId = productDto.CategoryId;
            var entity = _mapper.Map<Product>(productDto);
            _manager.Product.UpdateOneProduct(entity);
            _manager.Save();
        }
    }
}