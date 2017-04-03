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

            Console.WriteLine("Veuillez saisir les activités annexes (Code et Libellé :\n");
            Console.WriteLine("Veuillez saisir le code de l'activité :\n");
            //var GL = new Employé("Geneviève", "LECLERCQ", Metier._ANA);


            foreach (var a in EntréeTaches)
            {
                Console.WriteLine("Code : {0}\nLibellé {1}\n\n", a.Key, a.Value);
            }

            Console.ReadKey();
        }
    }
}
