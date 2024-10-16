using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRestSamples.CtrlSamples.Models;
using MyRestSamples.Model;

namespace MyRestSamples.CtrlSamples.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ProductDBContext _dbContext;

        public ProductsController(ProductDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> GetAllProducts([FromServices] ProductDBContext dbContext)
        {
            var products =await dbContext.Products.AsNoTracking().Include(c=>c.Brand).ToListAsync();
            foreach(var item in products)
            {
                item.Brand.Products = null;
            }
            return Ok(products);
        }

        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct([FromServices] ProductDBContext dbContext, int id)
        {
            var product = dbContext.Products.Where(c => c.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Post([FromBody]AddProductDto product)
        {
            var p=product.ToProduct();
           _dbContext.Products.Add(p);
            _dbContext.SaveChanges();
            return Ok(p.Id);
        }
    }
}
