using System.Text.Json.Serialization;
using Entities.Models;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Model;

public class SessionCart : Cart
{
    [JsonIgnore]
    public ISession? Session { get; set; }

    public static Cart GetCard(IServiceProvider services)
    {
        ISession? session = services
            .GetRequiredService<IHttpContextAccessor>()
            .HttpContext?
            .Session;

        SessionCart cart = session?.GetJson<SessionCart>("cart")
            ?? new SessionCart();

        cart.Session = session;
        return cart;
    }

    public override void AddItem(Product product, int quantity = 1)
    {
        base.AddItem(product, quantity);
        Session?.SetJson<SessionCart>("cart", this);
    }

    public override void RemoveLine(Product product)
    {
        base.RemoveLine(product);
        Session?.SetJson<SessionCart>("cart", this);
    }

    public override void Clear()
    {
        base.Clear();
        Session?.Remove("cart");
    }

}