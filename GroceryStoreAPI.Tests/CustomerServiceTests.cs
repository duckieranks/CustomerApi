using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryStoreAPI.Repositories;
using GroceryStoreAPI.Services;
using GroceryStoreAPI.Models;
using Moq;
using System.Collections.Generic;

namespace GroceryStoreAPI.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public void GetCustomerById_CustomerNonExistant_ReturnsNull()
        {
            var repo = new Mock<ICustomerRepository>();
            repo.Setup(s => s.GetDataSource())
                .Returns(GetTestCustomers());

            var service = new CustomerService(repo.Object);

            var result = service.GetCustomerById(3);

            Assert.AreEqual(result, null);
        }
        [TestMethod]
        public void UpdateCustomer_CustomerExistant_ReturnsTrue()
        {
            var repo = new Mock<ICustomerRepository>();
            repo.Setup(s => s.GetDataSource())
                .Returns(GetTestCustomers());

            var service = new CustomerService(repo.Object);

            var result = service.UpdateCustomer(2, "Test Two (updated)");

            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public void UpdateCustomer_CustomerNonExistant_ReturnsFalse()
        {
            var repo = new Mock<ICustomerRepository>();
            repo.Setup(s => s.GetDataSource())
                .Returns(GetTestCustomers());

            var service = new CustomerService(repo.Object);

            var result = service.UpdateCustomer(3, "Test Three");

            Assert.AreEqual(result, false);
        }
        [TestMethod]
        public void RemoveCustomer_CustomerExistant_ReturnsTrue()
        {
            var repo = new Mock<ICustomerRepository>();
            repo.Setup(s => s.GetDataSource())
                .Returns(GetTestCustomers());

            var service = new CustomerService(repo.Object);

            var result = service.RemoveCustomer(2);

            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public void RemoveCustomer_CustomerNonExistant_ReturnsFalse()
        {
            var repo = new Mock<ICustomerRepository>();
            repo.Setup(s => s.GetDataSource())
                .Returns(GetTestCustomers());

            var service = new CustomerService(repo.Object);

            var result = service.RemoveCustomer(3);

            Assert.AreEqual(result, false);
        }
        //Test for update
        //Test for delete
        //Test for getall
        private CustomerStore GetTestCustomers()
        {
            var s = new CustomerStore();
            s.customers = new List<Customer>();
            s.customers.Add(new Customer()
            {
                id = 1,
                name = "Test One"
            });
            s.customers.Add(new Customer()
            {
                id = 2,
                name = "Test Two"
            });
            return s;
        }
    }
}
