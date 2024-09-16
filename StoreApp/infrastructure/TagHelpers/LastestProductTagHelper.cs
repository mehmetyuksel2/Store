using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;

namespace StoreApp.infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "LastestProducts")]
    

    public class LastestProductTagHelper : TagHelper
    {//LastestProducts property ye sahip div için çalışacağız
        private readonly IServiceManager _manager;
        [HtmlAttributeName("number")]//***
        public int Number { get; set; }//tag üzerindeki number propertysi ile
                                    //serviceManager deki metodun üzerindeki
                                    //number bağlantılıdır.
        public LastestProductTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");//div tagı oluştur
            div.Attributes.Add("class", "my-3");//class özelliğine my-3 ekle

            TagBuilder h6 = new TagBuilder("h6");
            h6.Attributes.Add("class", "lead");

            TagBuilder icon = new TagBuilder("icon");
            icon.Attributes.Add("class", "fa fa-box text-secondary");


            h6.InnerHtml.AppendHtml(icon);//h6 taglarına icon tagını ekle
            h6.InnerHtml.AppendHtml(" Lastest Products");//h6 taglarına yazı ekle

            TagBuilder ul = new TagBuilder("ul");
            var products = _manager.ProductService.GetLastestProducts(5,false);
            foreach(Product product in products)
            {

                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href", $"/product/get/{product.ProductId}");
                a.InnerHtml.AppendHtml(product.ProductName);//h6 taglarına yazı ekle
                li.InnerHtml.AppendHtml(a);//li taglarına a tagı ekle
                ul.InnerHtml.AppendHtml(li);

            }
            div.InnerHtml.AppendHtml(h6);//div tagına h6 tagını ekle

            div.InnerHtml.AppendHtml(ul);//div tagına ul tagını ekle

            output.Content.AppendHtml(div);//çıktı ver

        }
    }
}
