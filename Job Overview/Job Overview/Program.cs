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

            int nombre = 1; // declaration et initialisation de nombre

            SortedList<int, string> EntréeTaches = new SortedList<int, string>();

            while (nombre != 0)//creation d'une boucle afin de rentrer la liste des taches par l'utilisateur. 
                               //l'utilisateur doit rentrer le chiffre 0 s'il a terminé d'entrer ses activités annexes
            {

                Console.WriteLine("Veuillez saisir le code de la tache a ajouter :");
                int b = int.Parse(Console.ReadLine());
                // Console.WriteLine("Le code saisi est : {0}\n", b);
                Console.WriteLine("Veuillez saisir le libellé de la tache a ajouter :");
                string a = Console.ReadLine();
                // Console.WriteLine("Le libellé correspondant au code {0} est : {1}\n", b, a);
                Tache n = new Tache(a, b);
                EntréeTaches.Add(b, a);
                Console.WriteLine("Veuillez rentrer 0 si vous ne souhaitez pas rentrer de nouvelles tache sinon, veuillez entrer une valeur différente à 0");
                nombre = int.Parse(Console.ReadLine());

            }

            Console.Clear();


            foreach (var a in EntréeTaches)
            {
                Console.WriteLine("Code : {0}\nLibellé {1}\n\n", a.Key, a.Value);
            }

            Console.ReadKey();
        }
    }
}
