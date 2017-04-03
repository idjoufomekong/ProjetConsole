using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Overview
{
    class Program
    {
        static void Main(string[] args)
        {

            Dal v = new Dal();
            v.ChargerDonnées();



            Console.WriteLine("test ok");
            Console.ReadKey();
        }
    }
}
