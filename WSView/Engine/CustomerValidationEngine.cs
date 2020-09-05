using WSView.Model;
using WSView.Resource;

namespace WSView.Engine
{
    public class CustomerValidationEngine
    {
        private readonly CustomerDA customerDA = new CustomerDA();

        public ValidationError[] ValidateUsername(string username)
        {
            Customer customer = customerDA.SelectByUsername(username);

            if (customer != null)
            {
                return new ValidationError[]
                {
                    new ValidationError
                    {
                        ValidationMessage = "The username is already used."
                    }
                };
            }

            return new ValidationError[0];
        }

    }
}
