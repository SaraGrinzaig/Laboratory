using Service.DTOs;

namespace Service.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(int customerId);
        void CreateCustomer(CustomerDto customer);
        void UpdateCustomer(CustomerDto customer);
        void DeleteCustomer(int customerId);
    }
}