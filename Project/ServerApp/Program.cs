using System;
using System.IO;
using System.Threading;
using Database;
using Domain.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using ServerApp.Data;

namespace ServerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread printer = new Thread(new ThreadStart(InvokeMethod));
            printer.Start();
            CreateHostBuilder(args).Build().Run();

            
        }

        static void InvokeMethod()
        {
            while (true)
            {
                Console.WriteLine(DateTime.Now + " Trigger check old messages");

                try
                {
                    new UnitOfWork(new SQLiteContext()).MessageRepository.CheckOldMessages();
                }
                catch (Exception e )
                {
                    Console.WriteLine(e);

                }
                Thread.Sleep(1000 * 60 * 60); // 60 Minutes
            }
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}