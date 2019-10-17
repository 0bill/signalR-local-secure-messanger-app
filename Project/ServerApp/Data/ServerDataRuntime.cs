using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public interface IServerDataRuntime
    {
        void msg();
    }
    public class ServerDataRuntime : IServerDataRuntime
    {
        private int x = 0;
        public void msg()
        {
            Console.WriteLine("Count" + x);
            x++;
        }
    }
}
