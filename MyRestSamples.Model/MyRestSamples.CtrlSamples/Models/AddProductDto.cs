using MyRestSamples.Model;

namespace MyRestSamples.CtrlSamples.Models
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int BrandId { get; set; }
        public Product ToProduct() => new Product
        {
            Name = Name,
            Description = Description,
            Price = Price,
            BrandId = BrandId
        };
    }
}
