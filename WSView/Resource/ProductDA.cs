using System;
using System.Configuration;
using System.Linq;
using WebShop.Infrastructure;
using WebShop.Model;

namespace WebShop.Resource
{

    public interface IProductDA
    {
        Product SelectByID(Guid id);

        void Insert(Product product);
        
        void Update(Product product);
        
        void Delete(Guid id);
    }

    public class ProductDA: IProductDA
    {
        private readonly Config config = new Config
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString
        };

        public Product SelectByID(Guid id)
        {
            return DataAccessHelper.Select<Product>(config, string.Format("SELECT * FROM Product WHERE ID ='{0}'", id)).FirstOrDefault();
        }

        public void Insert(Product product)
        {
            DataAccessHelper.Insert(config, string.Format("INSERT INTO Product(ID, Name, Price, Quantity) VALUES ('{0}', '{1}', {2}, {3})", product.ID, product.Name, product.Price, product.Quantity));
        }

        public void Update(Product product)
        {
            DataAccessHelper.Update(config, string.Format("UPDATE Customer SET Name = {0}, Price = {1}, Quantity = {2} WHERE ID = '{3}'", product.Name, product.Price, product.Quantity, product.ID));
        }

        public void Delete(Guid id)
        {
            DataAccessHelper.Delete(config, string.Format("DELETE FROM Product WHERE ID = '{0}'", id));
        }
    }
}
