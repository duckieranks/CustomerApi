using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryStoreAPI.Services;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Models;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Tests
{
    [TestClass]
    public class CustomerControllerTests
    {
        [TestMethod]
        public void GetCustomerById_CustomerNonExistant_ReturnsNotFound()
        {
            var service = new Mock<ICustomerService>();
            service.Setup(s => s.GetCustomerById(It.IsAny<int>()))
                .Returns((Customer)null);

            var controller = new CustomerController(service.Object);

            var result = controller.GetCustomerById(1);

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void RemoveCustomer_CustomerNonExistant_ReturnsNotFound()
        {
            var service = new Mock<ICustomerService>();
            service.Setup(s => s.RemoveCustomer(It.IsAny<int>()))
                .Returns(false);

            var controller = new CustomerController(service.Object);

            var result = controller.RemoveCustomer(It.IsAny<int>());

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void UpdateCustomer_CustomerNonExistant_ReturnsNotFound()
        {
            var service = new Mock<ICustomerService>();
            service.Setup(s => s.UpdateCustomer(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(false);

            var controller = new CustomerController(service.Object);

            var result = controller.UpdateCustomer(It.IsAny<int>(), It.IsAny<string>());

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
