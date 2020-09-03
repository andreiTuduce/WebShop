using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WebShop.Infrastructure;
using WebShop.Model;
using WebShop.Resource;

namespace WebShop.Manager
{
    public class CustomerManager
    {
        private readonly CustomerDA customerDA = new CustomerDA();

        public void CreateCustomer(Customer customer)
        {

            customerDA.Insert(customer);

        }

    }
}
