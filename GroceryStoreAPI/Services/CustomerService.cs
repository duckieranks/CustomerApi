using System;
using System.Collections.Generic;
using System.Linq;
using GroceryStoreAPI.Models;
using GroceryStoreAPI.Repositories;

namespace GroceryStoreAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public List<Customer> GetCustomers()
        {
            return _repo.GetDataSource().customers;
        }
        public Customer GetCustomerById(int customerId)
        {
            var customer = _repo.GetDataSource().customers.FirstOrDefault(c => c.id == customerId);
            if(customer != default)
            {
                return customer;
            }
            return null;
        }
        public void AddCustomer(string name)
        {
            var store = _repo.GetDataSource();
            int newId = store.customers.OrderByDescending(c => c.id).Select(c => c.id).FirstOrDefault() + 1;
            store.customers.Add(new Customer() { id = newId, name = name });
            _repo.WriteDataSource(store);
        }
        public bool RemoveCustomer(int customerId)
        {
            var store = _repo.GetDataSource();
            var customer = store.customers.FirstOrDefault(c => c.id == customerId);
            if(customer != null)
            {
                store.customers.Remove(customer);
                _repo.WriteDataSource(store);
                return true;
            }
            return false;
        }
        public bool UpdateCustomer(int customerId, string name)
        {
            var store = _repo.GetDataSource();
            var customer = store.customers.FirstOrDefault(c => c.id == customerId);
            if (customer != null)
            {
                customer.name = name;
                _repo.WriteDataSource(store);
                return true;
            }
            return false;
        }
    }
}
