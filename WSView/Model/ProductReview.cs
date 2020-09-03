using System;

namespace WebShop.Model
{
    public class ProductReview
    {
        public Guid ID { get; set; }

        public Guid ProductID { get; set; }

        public string Review { get; set; }

        public int Rating { get; set; }
    }
}
