using System.ComponentModel.DataAnnotations;

namespace MyAsp6Store.ShopUI.Models
{
    public class CheckOutViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
