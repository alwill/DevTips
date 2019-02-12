using System.Threading.Tasks;
using EfCoreInMemoryTests.Controllers;
using EfCoreInMemoryTests.Data;
using EfCoreInMemoryTests.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EfCoreInMemoryTests.Tests
{
    public class CreateCustomerServiceUnitTests
    {
        private ExampleContext _context;
        private CreateCustomerService _createCustomerService;

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ExampleContext>().UseInMemoryDatabase("Test");
            _context = new ExampleContext(dbContextOptions.Options);
            
            _createCustomerService = new CreateCustomerService(_context);
        }

        [Test]
        public async Task CreateCustomer_AmountOverOneThousand_CustomerMarkedAsPremium()
        {
            var newCustomer = new CreateCustomer
            {
                Name = "Alex",
                OrderTotal = 1001
            };

            var entityId = await _createCustomerService.CreateCustomer(newCustomer);

            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.Id == entityId);
            Assert.That(newCustomer.Name, Is.EqualTo(customer.Name), "Names are equal");
            Assert.That(CustomerStatus.Premium, Is.EqualTo(customer.Status), "Status is Premium");
        }

        [Test]
        public async Task CreateCustomer_AmountUnderOneThousand_CustomerMarkedAsStandard()
        {
            var newCustomer = new CreateCustomer
            {
                Name = "Alex",
                OrderTotal = 999
            };

            var entityId = await _createCustomerService.CreateCustomer(newCustomer);

            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.Id == entityId);
            
            Assert.That(newCustomer.Name, Is.EqualTo(customer.Name), "Names are equal");
            Assert.That(CustomerStatus.Standard, Is.EqualTo(customer.Status), "Status is Standard");
        }
    }
}