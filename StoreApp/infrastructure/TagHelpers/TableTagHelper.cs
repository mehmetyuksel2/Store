using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.infrastructure.TagHelpers
{
    [HtmlTargetElement("table")]//table etiketi için çalışacağız
    public class TableTagHelper : TagHelper
    {//bu özelliği kullanmak için kullandığımız dizinin _ViewImport a "@addTagHelper <Mevcut ProjeAdı>" import edilir
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "table table-hover");//table etiketine class özelliğine table classı eklenir
        }
    }
}
