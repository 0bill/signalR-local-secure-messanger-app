using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace Server
{
    class Program
    {
        private static string url = "http://localhost:8080";
       
            static void Main(string[] args)
            {
                
                using (WebApp.Start<Startup>(url))
                {
                    Console.WriteLine("Server starts...");
                    Console.ReadLine();
                }
            }
        
    }
}
