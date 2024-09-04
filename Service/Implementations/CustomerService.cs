using Service.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using AutoMapper;
using Service.DTOs;

namespace Service.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public CustomerDto GetCustomerById(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            return _mapper.Map<CustomerDto>(customer);
        }

        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _customerRepository.InsertCustomer(customer);
            _customerRepository.Save();
            return _mapper.Map<CustomerDto>(customer);
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _customerRepository.UpdateCustomer(customer);
            _customerRepository.Save();
        }

        public void DeleteCustomer(int customerId)
        {
            _customerRepository.DeleteCustomer(customerId);
            _customerRepository.Save();
        }
    }
}
