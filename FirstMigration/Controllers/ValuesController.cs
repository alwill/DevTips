using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMigration.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstMigration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly TestDbContext context;

        public ValuesController(TestDbContext context)
        {
            this.context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await context.Order.Include(o => o.Items).ToListAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
