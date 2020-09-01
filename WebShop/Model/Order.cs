using System;

namespace WebShop.Model
{
    public class Order
    {
        public Guid ID { get; set; }

        public Guid ProductID { get; set; }

        public decimal TotalCost { get; set; }
    }
}
