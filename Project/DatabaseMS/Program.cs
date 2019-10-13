using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DatabaseMS
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var model = new DatabaseContext())
            {
              

                var tables = model.Users.Select(x => x).ToList();
                foreach (var x in tables)
                {
                    Console.WriteLine(x.Id + x.Username);
                }

                Console.ReadKey();
            }


        }
    }
}
