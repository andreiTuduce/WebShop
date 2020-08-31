using System;
using WebShop.Model;
using WebShop.Resource;

namespace WebShop
{
    class Program
    {
        static void Main(string[] args)
        {

            Customer customer = new Customer
            {
                ID = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                CustomerType = CustomerType.New
            };

            CustomerDA customerDA = new CustomerDA();

            customerDA.Insert(customer);
        }
    }
}
