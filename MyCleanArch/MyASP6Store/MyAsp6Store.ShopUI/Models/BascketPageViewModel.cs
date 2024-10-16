using Microsoft.AspNetCore.Mvc;

namespace MyAsp6Store.ShopUI.Models
{
    public class BascketPageViewModel 
    {
        public Bascket Bascket { get; set; }
        public string ReturnUrl { get; set; }
    }
}
