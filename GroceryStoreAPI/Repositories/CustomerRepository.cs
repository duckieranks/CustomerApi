using GroceryStoreAPI.Models;
using GroceryStoreAPI.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerStore GetDataSource()
        {
            using (StreamReader r = new StreamReader("database.json"))
            {
                string json = r.ReadToEnd();
                var store = JsonConvert.DeserializeObject<CustomerStore>(json);
                return store;
            }
        }
        public void WriteDataSource(CustomerStore store)
        {
            File.WriteAllText("database.json", JsonConvert.SerializeObject(store));
        }
    }
}
