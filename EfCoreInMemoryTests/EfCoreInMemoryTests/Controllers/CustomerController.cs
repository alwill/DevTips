using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreInMemoryTests.Data;
using EfCoreInMemoryTests.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreInMemoryTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CreateCustomerService _createCustomerService;

        public CustomerController(CreateCustomerService createCustomerService)
        {
            _createCustomerService = createCustomerService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomer customer)
        {
          var id = await _createCustomerService.CreateCustomer(customer);
          return new OkObjectResult(id);
        }
    }

    public class CreateCustomerService
    {
        private readonly ExampleContext _context;

        public CreateCustomerService(ExampleContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCustomer(CreateCustomer customer)
        {
            var newCustomer = new Customer
            {
                Name = customer.Name,
                OrderTotal = customer.OrderTotal,
                Status = CustomerStatus.Standard
            };
            
            if (customer.OrderTotal >= 1000)
            {
                newCustomer.Status = CustomerStatus.Premium;
            }

            var entity = await _context.Customer.AddAsync(newCustomer);

            await _context.SaveChangesAsync();

            return entity.Entity.Id;
        }
    }

    public class CreateCustomer
    {
        public string Name { get; set; }
        public int OrderTotal { get; set; }
    }
}