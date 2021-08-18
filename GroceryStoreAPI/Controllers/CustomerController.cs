using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.Models;
using GroceryStoreAPI.Services;
using Newtonsoft.Json;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        [HttpGet("/api/[controller]/")]
        public ActionResult<List<Customer>> GetCustomers()
        {
            return _service.GetCustomers();
        }
        [HttpGet("{customerId}")]
        public ActionResult<Customer> GetCustomerById(int customerId)
        {
            var customer = _service.GetCustomerById(customerId);
            if(customer != null)
            {
                return customer;
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("add/{name}")]
        public ActionResult AddCustomer(string name)
        {
            _service.AddCustomer(name);
            return new OkResult();
        }
        [HttpPost("remove/{id}")]
        public ActionResult RemoveCustomer(int id)
        {
            var success = _service.RemoveCustomer(id);
            if (success)
            {
                return new OkResult();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("update/{id}/{name}")]
        public ActionResult UpdateCustomer(int id, string name)
        {
            var success = _service.UpdateCustomer(id, name);
            if (success)
            {
                return new OkResult();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
