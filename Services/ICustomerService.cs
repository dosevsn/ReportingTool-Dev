using AngularReporting.Model;

namespace AngularReporting.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
    }
}
