using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParam
{
    public class ProductRequestParameters : RequestParameters
    {//product ile ilgili filtreleme, listeleme veya sayfalama gibi işlemler yapılırken endpointte yakalanan parametreleri burada saklarız
        public int? CategoryId { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; } = int.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;// true/false
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ProductRequestParameters() : this(1,6)//constructor daki parametrelere default değerler veriyoruz
        {
            
        }
        public ProductRequestParameters(int pageNumber=1, int pageSize=6)//default değerleri bu şekildede verebiliriz
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            
        }
    }
    
}
