using System;

namespace WSView.Model
{
    public class Product
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
    }
}
