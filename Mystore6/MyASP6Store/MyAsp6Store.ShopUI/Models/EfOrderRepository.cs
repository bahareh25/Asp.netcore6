namespace MyAsp6Store.ShopUI.Models
{
    public class EfOrderRepository : IOrderRepository
    {
        private readonly StorDbContext storDbContext;

        public EfOrderRepository(StorDbContext storDbContext)
        {
            this.storDbContext = storDbContext;
        }
        public void Save(Order order)
        {
            storDbContext.AttachRange(order.orderDetails.Select(c=>c.Product));
            storDbContext.orders.Add(order);
            storDbContext.SaveChanges();
        }
    }
}
