using System.Text.Json.Serialization;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using StoreApp.infrastructure.Extensions;

namespace StoreApp.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession? Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;//IServiceProvider �zerinden IHttpContextAccessor a ula��yoruz


            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();//session dan sepet bilgisini al�r yoksa yeni sepet olu�turulur.
            cart.Session = session;

            return cart;
        }
        public override void AddItem(Product product, int quantity)
        {//mevcuttaki cart, session ile k�sa s�reli haf�zaya al�n�r
            base.AddItem(product,quantity);
            Session.SetObject<SessionCart>("cart", this);
        }

        public override void Clear()
        {//session i�indeki cart bo�alt�l�r
            base.Clear();
            Session?.Remove("cart");
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session?.SetObject<SessionCart>("cart", this);
        }

    }
}