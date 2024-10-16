namespace MyAsp6Store.ShopUI.Models
{
    public class EfCategoryRepository:ICategoryRepository
    {
        private readonly StorDbContext storeDBContext;

        public EfCategoryRepository(StorDbContext storeDBContext)
        {
            this.storeDBContext = storeDBContext;
        }
        public List<string> GetAllCategory() =>
               storeDBContext.categories.Select(c => c.Name).ToList();
    }
}
