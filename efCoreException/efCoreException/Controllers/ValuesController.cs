using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace efCoreException.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly EfExceptionContext _context;

        public ValuesController(EfExceptionContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Example>> Get()
        {
            return _context.Example.Where(IsReferencedAndStartsWithB()).ToList();
        }

        private Expression<Func<Example, bool>> IsReferencedAndStartsWithB()
        {
            return e => e.IsReferenced && e.ReferenceName.StartsWith("B");
        }
    }
}
