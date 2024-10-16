namespace MyAsp6Store.ShopUI.Models
{
    public class SessionBascket : Bascket
    {
        private ISession _session;
        public static SessionBascket GetBascket(IServiceProvider service)
        {
            var session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            SessionBascket bascket = session.GetJson<SessionBascket>("Bascket") ?? new SessionBascket();
            bascket._session = session;
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
}
