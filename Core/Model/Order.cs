using System;

namespace Core.Model
{
    public class Order
    {
        public Guid ID { get; set; }

        public Guid ProductID { get; set; }

        public decimal ProductCost { get; set; }
    }
}
