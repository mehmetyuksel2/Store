using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreApp.Models;

namespace StoreApp.infrastructure.TagHelpers
{
    [HtmlTargetElement("div",Attributes="page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory;
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        //viewContext bir görünümdür.
        public Pagination PageModel{ get; set; }
        public String? PageAction { get; set; }
        public bool PageClassesEnabled { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext is not null && PageModel is not null)
            {
                IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");
                for (int i = 1;i<=PageModel.TotalPages;i++)
                {
                    TagBuilder tag = new TagBuilder("a");// a tagı oluşturuyoruz
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { PageNumber = i });//a tagına link veriyoruz
                    if(PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrenPage ? PageClassSelected : PageClassNormal);

                    }
                    tag.InnerHtml.Append(i.ToString());// a tagının içine totalpages ları sayı ekliyoruz
                    result.InnerHtml.AppendHtml(tag);// resultun yani div tagının içine a tagını ekliyoruz
                }
                output.Content.AppendHtml(result.InnerHtml);//çıktı alıyoruz
            }
        }

    }
}
