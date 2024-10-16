namespace MyAsp6Store.ShopUI.Models
{
    public class EfProductRepository : IProductRepository
    {
        private readonly StorDbContext storeDBContext;
       
        public EfProductRepository(StorDbContext storeDBContext)
        {
            this.storeDBContext = storeDBContext;
        }

        public PagedData<Product> GetAll(int pageNumber,int pageSize,string category)
        {
            var result = new PagedData<Product>
            {
                PageInfo = new PageInfo
                {
                    PageSize = pageSize,
                    PageNumber = pageNumber
                }
            };
            result.Data= storeDBContext.products.Where(c=>string.IsNullOrWhiteSpace(category)||c.Category.Name==category).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            result.PageInfo.TotalCount=storeDBContext.products.Where(c => string.IsNullOrWhiteSpace(category) || c.Category.Name == category).Count();
            return result;
        }

       

        public Product GetById(int id)
        {
            return storeDBContext.products.FirstOrDefault(p => p.Id == id);
        }
    }
}
