namespace MyAsp6Store.ShopUI.Components;

    public class CategorySideBoxViewComponent:ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategorySideBoxViewComponent(ICategoryRepository categoryRepository)
        {
        _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var currentcategory = RouteData?.Values["category"];
            ViewBag.Category = currentcategory;
            return View(_categoryRepository.GetAllCategory());
        }
    }
