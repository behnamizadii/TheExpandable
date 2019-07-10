using System.Collections.Generic;

namespace TheExpandable.Entities
{
    public class Basket
    {
        public string BasketId { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<int, decimal> Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}