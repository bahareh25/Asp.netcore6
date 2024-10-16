﻿namespace MyAsp6Store.ShopUI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
