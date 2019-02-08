using System.Linq;
using AspNetCoreInitializationTasks.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreInitializationTasks.Data
{
    public class ExampleDbInitializer
    {
        public static void Initialize(ExampleDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Person.Any())
            {
                return;
            }
            
            var person1 = new Person
            {
                Name = "Alex Will",
                Age = 24
            };

            var person2 = new Person
            {
                Name = "Billy Bob",
                Age = 85
            };

            var person3 = new Person
            {
                Name = "Sarah Walker",
                Age = 33
            };
            
            context.Person.AddRange(person1,person2,person3);
            context.SaveChanges();
        }
    }
}