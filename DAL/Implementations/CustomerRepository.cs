﻿using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LaboratoryContext _context;

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
            var customer = _context.Customers.Find(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _context.Customers.Find(customer.Id);
            if (existingCustomer != null)
            {
                _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}