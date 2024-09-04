using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private LaboratoryContext _context;

        public CustomerRepository(LaboratoryContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.Find(customerId);
        }

        public void InsertCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customer = _context.Customers.Find(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
