using System;
using System.Configuration;
using System.Linq;
using WebShop.Infrastructure;
using WebShop.Model;

namespace WebShop.Resource
{
    public interface IOrderDA
    {
        Order SelectByID(Guid id);

        void Insert(Order customer);

        void Update(Order customer);

        void Delete(Guid id);
    }

    public class OrderDA : IOrderDA
    {

        private readonly Config config = new Config
        {

            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"]
        };

        public Order SelectByID(Guid id)
        {
            return DataAccessHelper.Select<Order>(config, string.Format("SELECT * FROM Order WHERE ID ='{0}'", id)).FirstOrDefault();
        }

        public void Insert(Order order)
        {
            DataAccessHelper.Insert(config, string.Format("INSERT INTO Order(ID, ProductID, TotalCost) VALUES ('{0}', '{1}', {2})", order.ID, order.ProductID, order.TotalCost));
        }

        public void Update(Order order)
        {
            DataAccessHelper.Update(config, string.Format("UPDATE Customer SET ProductID = {0}, TotalCost = {1} WHERE ID = '{2}'", order.ProductID, order.TotalCost, order.ID));
        }

        public void Delete(Guid id)
        {
            DataAccessHelper.Delete(config, string.Format("DELETE FROM Order WHERE ID = '{0}'", id));
        }
    }
}
