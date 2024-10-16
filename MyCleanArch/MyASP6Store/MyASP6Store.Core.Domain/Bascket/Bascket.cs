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

