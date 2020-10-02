using Core.Model;
using Core.Resource;
using System;
using WebShop.Infrastructure;

namespace Core.Manager
{
    public class CustomerManager
    {
        private readonly CustomerDA customerDA = new CustomerDA();

        public void CreateCustomer(Customer customer)
        {
            customer.ID = Guid.NewGuid();
            customer.CustomerType = CustomerType.New;

            customer.Password = customer.Password.GetHashedString();
            
            customerDA.Insert(customer);
        }

    }
}
