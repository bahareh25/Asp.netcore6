namespace MyAsp6Store.ShopUI.Models;

    public class Bascket
    {
        private List<BascketItem> _items=new();
        public virtual void Add(Product product , int quantity)
        { 
        var bascketItem=_items.Where(c=>c.Product.Id==product.Id).FirstOrDefault();
            if (bascketItem != null) { 
                bascketItem.Quantity += quantity;
            }
            else
            {
               _items.Add(new BascketItem()
               {
                   Product= product,
                   Quantity= quantity
               });
            }
        }
        public virtual void Remove(Product product)=>
            _items.RemoveAll(c=>c.Product.Id== product.Id);
       public int TotalPrice()=>
            _items.Sum(c=>c.Quantity*c.Product.Price);
        public virtual void Clear()=>_items.Clear();
        public IEnumerable<BascketItem> Items =>_items;

    }
public class SessionBascket:Bascket
{
    private  ISession _session;
    public static SessionBascket GetBascket(IServiceProvider service)
    {
        var session=service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
        SessionBascket bascket = session.GetJson<SessionBascket>("Bascket")?? new SessionBascket();
        bascket._session=session;
        return bascket;
    }
    public override void Add(Product product, int quantity)
    {
        base.Add(product, quantity);
        _session.SetJson("Bascket", this);
    }
    public override void Remove(Product product)
    {
        base.Remove(product);
        _session.SetJson("Bascket", this);
    }
    public override void Clear()
    {
        base.Clear();
        _session.Remove("Bascket");
    }
}
    public class BascketItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

