using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using ServerApp.Data;

namespace ServerApp
{
    public class Test
    {
        private IServerDataRuntime _dataRuntime;

        public Test(IServerDataRuntime dataRuntime)
        {
            this._dataRuntime = dataRuntime;
        }


        public void elos()
        {
            _dataRuntime.msg();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();


        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
