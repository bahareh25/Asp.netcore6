namespace MyAsp6Store.ShopUI.Components
{
    public class BascketSummeryViewComponent:ViewComponent
    {
        private readonly Bascket bascket;

        public BascketSummeryViewComponent(Bascket bascket)
        {
            this.bascket = bascket;
        }
        public IViewComponentResult Invoke()
        {
            return View(bascket);
        }
    }
}
