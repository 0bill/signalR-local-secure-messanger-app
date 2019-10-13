using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public interface IServerRuntimeData
    {
        void msg();
    }
    public class ServerRuntimeData : IServerRuntimeData
    {
        private int x = 0;
        public void msg()
        {
            Console.WriteLine("Tutaj jestem" + x);
            x++;
        }
    }
}
