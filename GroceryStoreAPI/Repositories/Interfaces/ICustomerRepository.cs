using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Repositories
{
    public interface ICustomerRepository
    {
        CustomerStore GetDataSource();
        void WriteDataSource(CustomerStore store);
    }
}
