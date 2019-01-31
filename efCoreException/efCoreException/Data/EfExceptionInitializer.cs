using System.Collections.Generic;
using System.Linq;

public static class EfExceptionInitializer
{
    public static void Initialize(EfExceptionContext context)
    {
        if (context.Example.Any())
        {
            return;
        }

        var list = new List<Example> {
             new Example { IsReferenced = false, ReferenceName = "Golden" },
             new Example { IsReferenced = true, ReferenceName = "Brown" },
             new Example { IsReferenced = false, ReferenceName = "Black" }
             };

        context.Example.AddRange(list);
        context.SaveChanges();
    }
}