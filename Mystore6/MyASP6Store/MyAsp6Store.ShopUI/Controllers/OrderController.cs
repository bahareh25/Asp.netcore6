using Microsoft.AspNetCore.Mvc;

namespace MyAsp6Store.ShopUI.Controllers
{
    public class OrderController : Controller
      {
        private readonly IOrderRepository orderRepository;
        private readonly Bascket bascket;

       public OrderController(IOrderRepository orderRepository,Bascket bascket)
        {
            this.orderRepository = orderRepository;
          this.bascket = bascket;
        }

       

        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(CheckOutViewModel model)
        {
            if(!bascket.Items.Any())
            {
                ModelState.AddModelError("", "ther is not any item in Bascket");
            }
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Name = model.Name,
                    City = model.City,
                    Address = model.Address,
                };
                foreach (var item in bascket.Items)
                {
                    order.orderDetails.Add(new OrderDetail
                    {
                        Product = item.Product,
                        Quantity = item.Quantity,
                    });
                }

                orderRepository.Save(order);
                bascket.Clear();
                return RedirectToAction("Compelet");
            }
           
            return View(model);
        }
        public IActionResult Compelet()
        {
            return View();
        }
    }
}
