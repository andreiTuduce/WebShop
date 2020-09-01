using System;
using System.Configuration;
using System.Linq;
using WebShop.Infrastructure;
using WebShop.Model;

namespace WebShop.Resource
{
    public interface ICustomerDA
    {
        Customer SelectByID(Guid id);

        void Insert(Customer customer);

        void Update(Customer customer);

        void Delete(Guid id);
    }

    public class CustomerDA: ICustomerDA
    {
        private readonly Config config = new Config
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"]
        };

        public Customer SelectByID(Guid id)
        {
            return DataAccessHelper.Select<Customer>(config, string.Format("SELECT * FROM Customer WHERE ID = {0}", id)).FirstOrDefault();
        }

        public void Insert(Customer customer)
        {
            string sql = string.Format("INSERT INTO Customer(ID, FirstName, LastName, Type) VALUES ('{0}', '{1}', '{2}', {3})", customer.ID, customer.FirstName, customer.LastName, (int)customer.CustomerType);

            DataAccessHelper.Insert(config, sql);
        }

        public void Update(Customer customer)
        {
            string sql = string.Format("UPDATE Customer SET FirstName = {0}, LastName = {1}, Type = {2} WHERE ID = '{3}'", customer.FirstName, customer.LastName, customer.CustomerType, customer.ID);

            DataAccessHelper.Update(config, sql);
        }

        public void Delete(Guid id)
        {
            string sql = string.Format("DELETE FROM Customer WHERE ID = '{0}'", id);

            DataAccessHelper.Delete(config, sql);
        }
    }
}
