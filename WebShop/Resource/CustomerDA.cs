using System;
using System.Linq;
using WebShop.Infrastructure;
using WebShop.Model;

namespace WebShop.Resource
{
    public class CustomerDA
    {
        private readonly Config config;
        private readonly string selectFrom = "SELECT * FROM Customer WHERE ID = {0}";

        public CustomerDA()
        {
            config = new Config
            {
                ConnectionString = "Data Source=DESKTOP-IE1OTAU;Initial Catalog=WebShop;Integrated Security=True"
            };
        }

        public Customer Select(Guid id)
        {
            return DataAccessHelper.Select<Customer>(config, string.Format(selectFrom, id)).FirstOrDefault();
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
