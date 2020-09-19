using Core.Model;
using Core.Resource;
using System;

namespace Core.Manager
{
    public class CustomerManager
    {
        private readonly CustomerDA customerDA = new CustomerDA();

        public void CreateCustomer(Customer customer)
        {
            customer.ID = Guid.NewGuid();
            customer.CustomerType = CustomerType.New;
            
            customerDA.Insert(customer);
        }

    }
}
