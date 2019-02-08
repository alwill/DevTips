using System.Linq;
using EfCoreEnumConversion.Entities;

namespace EfCoreEnumConversion.Data
{
    public class ExampleInitializer
    {
        public static void Initialize(ExampleContext context)
        {
            if (context.Candidate.Any())
            {
                return;
            }

            var candidate1 = new Candidate
            {
                Name = "Undecided Person",
                Party = Party.Unknown
            };

            var candidate2 = new Candidate
            {
                Name = "D Party",
                Party = Party.Democrat
            };

            var candidate3 = new Candidate
            {
                Name = "R Party",
                Party = Party.Republican
            };

            var candidate4 = new Candidate
            {
                Name = "Other Party",
                Party = Party.Other
            };

            context.Candidate.AddRangeAsync(candidate1, candidate2, candidate3, candidate4);
            context.SaveChanges();
        }
    }
}