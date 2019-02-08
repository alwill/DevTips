﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreInitializationTasks.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCoreInitializationTasks
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = CreateWebHostBuilder(args).Build();

           using (var scope = host.Services.CreateScope())
           {
               var context = scope.ServiceProvider.GetService<ExampleDbContext>();
               var log = scope.ServiceProvider.GetService<ILogger<Program>>();
               
               ExampleDbInitializer.Initialize(context);

               try
               {
                   host.Run();
               }
               catch (Exception ex)
               {
                   log.LogCritical(ex, "Site fail");
               }
           }
           
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}