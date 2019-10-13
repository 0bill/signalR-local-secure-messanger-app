using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace Server
{
    class Program
    {
        private static string url = "http://localhost:8080";
        private static IDisposable SignalR { get; set; }


        static void Main(string[] args)
        {
            Task.Run(StartServer);
            Console.ReadKey();
        }

        public static void StartServer()
        {

            try
            {
                SignalR = WebApp.Start(url);
                Console.WriteLine("Server started...");
            }
            catch (TargetInvocationException)
            {
                Console.WriteLine("Server fail...");
            }

            Console.WriteLine("Server started at " + url);
        }
    }
}