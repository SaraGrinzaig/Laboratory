using Service.DTOs;

namespace Service.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(int customerId);
        CustomerDto CreateCustomer(CustomerDto customer);
        void UpdateCustomer(CustomerDto customer);
        void DeleteCustomer(int customerId);
    }
}