using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int customerId);
        void AddCustomer(string name);
        bool RemoveCustomer(int customerId);
        bool UpdateCustomer(int customerId, string name);
    }
}
