using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WebShop.Infrastructure;
using WebShop.Resource;
using WSView.Engine;
using WSView.Model;
using WSView.Resource;

namespace WSView.Manager
{
    public class CustomerManager: ICustomerManager
    {
        private readonly CustomerDA customerDA = new CustomerDA();
        private readonly CustomerValidationEngine customerValidationEngine = new CustomerValidationEngine();

        public ValidationError[] CreateCustomer(Customer customer)
        {

            ValidationError[] errors = customerValidationEngine.ValidateUsername(customer.Username);

            if(errors.Length == 0)
                customerDA.Insert(customer);

            return errors;
        }

    }
}
