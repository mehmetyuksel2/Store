using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> FilterByCategoryId(this IQueryable<Product> products,
            int? categoryId)// category ye göre sorgu yapar
        {
            if (categoryId is null)
                return products;//tüm listenin gösterilmesi
            else
                return products.Where(prd => prd.CategoryId.Equals(categoryId));//gönderilen categoryId nin productta aranması
        }
        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> product,
            String? searchTerm)//bu metod ProductRepository den çağırılıyor
        {
            if(string.IsNullOrWhiteSpace(searchTerm))//boşsa yada boşluktan oluşuyor ise
                return product;//tüm listenin gösterilmesi
            else
                return product.Where(prd => prd.ProductName.ToLower()
                    .Contains(searchTerm.ToLower()));//gönderilen kelimenin productta aranması
        }
        public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products,
            int? MinPrice, int MaxPrice, bool isValidePrice)
        {
            if(isValidePrice)
            {
                return products.Where(prd => prd.Price >= MinPrice &&
                prd.Price <= MaxPrice);
            }
            else
            {
                return products;
            }
        }
    }
}
