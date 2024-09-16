using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParam
{
    public abstract class RequestParameters
    {// daha genel endpoint parametreleri burada yakalanır. daha spesifik parametreler için bu sınıf kalıtım verilir ve o sınıflarda daha özel metodlar yazılır
        public String? SearchTerm { get; set; }//formla uyuşması için değişken ismi aynı olmalıdır name ile
        
    }
    
}
