using System;
using System.Configuration;
using System.Linq;
using WebShop.Infrastructure;
using WebShop.Model;

namespace WebShop.Resource
{
    public interface IProductReviewDA
    {
        ProductReview SelectByID(Guid id);

        void Insert(ProductReview productReview);

        void Update(ProductReview productReview);

        void Delete(Guid id);
    }

    public class ProductReviewDA : IProductReviewDA
    {

        private readonly Config config = new Config
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString
        };

        public ProductReview SelectByID(Guid id)
        {
            return DataAccessHelper.Select<ProductReview>(config, string.Format("SELECT * FROM ProductReview WHERE ID ='{0}'", id)).FirstOrDefault();
        }

        public void Insert(ProductReview productReview)
        {
            DataAccessHelper.Insert(config, string.Format("INSERT INTO ProductReview(ID, ProductID, Review, Rating) VALUES ('{0}', '{1}', '{2}', {3})", productReview.ID, productReview.ProductID, productReview.Review, productReview.Rating));
        }

        public void Update(ProductReview productReview)
        {
            DataAccessHelper.Update(config, string.Format("UPDATE Customer SET ProductID = {0}, Review = {1}, Rating = {2} WHERE ID = '{3}'", productReview.ProductID, productReview.Review, productReview.Rating, productReview.ID));
        }

        public void Delete(Guid id)
        {
            DataAccessHelper.Delete(config, string.Format("DELETE FROM ProductReview WHERE ID = '{0}'", id));
        }

    }
}
