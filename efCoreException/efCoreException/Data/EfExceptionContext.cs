using Microsoft.EntityFrameworkCore;

public class EfExceptionContext : DbContext
{
    public EfExceptionContext(DbContextOptions<EfExceptionContext> options) : base(options)
    {
    }
    public virtual DbSet<Example> Example { get; set; }
}