using Microsoft.AspNetCore.Mvc;
using MyAsp6Store.ShopUI.Models;

namespace MyAsp6Store.ShopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;
        private int pageSize = 2;
        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index(string category="",int pageNumber=1)
        {
            var viewModel = new ProductListViewModel
            {
                CurrentCategory = category,
                Data = productRepository.GetAll(pageNumber, pageSize, category)
            
            };
            return View(viewModel);
        }
    }
}
