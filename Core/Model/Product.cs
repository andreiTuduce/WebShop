using System;

namespace Core.Model
{
    public class Product
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
