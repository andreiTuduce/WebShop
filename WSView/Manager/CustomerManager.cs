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

        public Customer GetCustomer(string username)
        {
            return customerDA.SelectByUsername(username);
        }

    }
}
