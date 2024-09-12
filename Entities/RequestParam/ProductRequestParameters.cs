using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParam
{
    public class ProductRequestParameters : RequestParameters
    {//product ile ilgili filtreleme, listele veya sayfalama gibi işlemler yapılırken endpointte yakalanan verileri burada saklarız
        public int? CategoryId { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; } = int.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;// true/false
    }
}
