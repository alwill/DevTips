using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelCollectionInitialization.Data;
using ModelCollectionInitialization.Entities;

namespace ModelCollectionInitialization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ExampleContext _context;
        public OrderController(ExampleContext context)
        {
            _context = context;
        }

        [HttpGet("{orderId:int}/count")]
        public async Task<IActionResult> GetAsync(int orderId)
        {
            var order = await _context.Order.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == orderId);

            if (order is null)
            {
                return NotFound();
            }

            return new OkObjectResult(order.Items.Count());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrderModel order)
        {
            if (order.Items.Count() == 0)
            {
                return new BadRequestObjectResult("Order must have items");
            }
            
            var newOrder = new Order { Name = order.Name };
            order.Items.ToList().ForEach(i => newOrder.Items.Add(new Item { Name = i.Name }));

            _context.Order.Add(newOrder);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public class OrderModel
    {
        public OrderModel()
        {
            Items = new List<ItemModel>();
        }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public IList<ItemModel> Items { get; }
    }

    public class ItemModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
    }
}
