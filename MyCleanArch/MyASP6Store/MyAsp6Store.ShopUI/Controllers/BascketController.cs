namespace MyAsp6Store.ShopUI.Controllers;

    public class BascketController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly Bascket sessionBascket;

    public BascketController(IProductRepository productRepository,Bascket sessionBascket)
        {
            this.productRepository = productRepository;
        this.sessionBascket = sessionBascket;
    }
        public IActionResult Index(string returnUrl)
        {
            BascketPageViewModel bascketPageViewModel = new BascketPageViewModel
            {
                //Bascket =GetBasket(),
                Bascket = sessionBascket, 
                ReturnUrl = returnUrl,
            };
          
            return View(bascketPageViewModel);
        }
        [HttpPost]
        public IActionResult AddtoBascket(int productId, string returnUrl)
        {
            var product=productRepository.GetById(productId);
        // var bascket = GetBasket();
        sessionBascket.Add(product, 1);
           // bascket.Add(product,1);
           // SaveBascket(bascket);
            return RedirectToAction("Index", new {returnUrl=returnUrl});
        }
        [HttpPost]
        public IActionResult RemoveFromBascket(int productId, string returnUrl)
        {
            var product = productRepository.GetById(productId);
        //var bascket = GetBasket();
        sessionBascket.Remove(product);
            //bascket.Remove(product);
            //SaveBascket(bascket);
            return RedirectToAction("Index", new { returnUrl = returnUrl });
        }
        //private Bascket GetBasket()
        //{
        //    return HttpContext.Session.GetJson<Bascket>("Bascket");
        //   // var bascketString = HttpContext.Session.GetString("Bascket");
        //   // if(string.IsNullOrEmpty(bascketString))
        //   // { 
        //   //     return new Bascket(); 
        //   // }
        //   //return JsonConvert.DeserializeObject<Bascket>(bascketString);
        //}
        //private void SaveBascket(Bascket bascket)
        //{
        //    HttpContext.Session.SetJson("Bascket",bascket);
        //}
    }

