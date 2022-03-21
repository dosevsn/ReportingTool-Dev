using AngularReporting.Data;
using AngularReporting.Model;

namespace AngularReporting.Services
{
    public class CustomerService : ICustomerService
    {
        private FMCContext _context {get;set;}
        public CustomerService(FMCContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var list = _context.Customers.ToList();

            return list;
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Find(id);
        }
    }
}
