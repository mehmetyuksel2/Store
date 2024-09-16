using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.infrastructure.Extensions;// buraya import etmemiz gerekiyor tabi
//extensions metodlar static olur ve verilen ilk parametre genişletillen ifadenin type ı yazılır
namespace StoreApp.Pages
{// code behind
    public class DemoModel : PageModel
    {
        public String? FullName => HttpContext?.Session?.GetString("name") ?? "";// sesion okuma
        public DemoModel()
        {

        }
        public void OnGet()
        {

        }
        public void OnPost([FromForm]string name)
        {
            //FullName = name;
            HttpContext.Session.SetString("name",name); // session atama

        }
    }
}