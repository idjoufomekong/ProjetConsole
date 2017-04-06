using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverviewBis
{
    class Program
    {
        static void Main(string[] args)
        {
            AfficherActivités();

            Console.ReadKey();
            Console.Clear();
        }

        static void AfficherActivités()
        {
            Console.WriteLine("Saisie des activités annexes\n");
            ConsoleKeyInfo ki ;
            

            SortedDictionary<string, ActivitéAnnexe> EntréeActivités = new SortedDictionary<string, ActivitéAnnexe>();

            do

            {
                string b;
                string a;

                Console.WriteLine("Veuillez saisir le code de l'activité à ajouter :");
                b = Console.ReadLine();
                Console.WriteLine("Veuillez saisir le libellé de la tache a ajouter :");
                a = Console.ReadLine();

                try
                {
                    EntréeActivités.Add(b, new ActivitéAnnexe(b, a));

                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Le code doit être unique");
                }
                Console.WriteLine("Appuyer sur Echap pour sortir ou une autre touche pour continuer");
                ki = Console.ReadKey(true);

            }
            while (ki.Key != ConsoleKey.Escape);
            Console.Clear();
            //affichage des activités annexes saisies
            Console.WriteLine("Liste des activités annexes saisies classées selon leur code :\n");
            foreach (var a in EntréeActivités)
            {
                Console.WriteLine("Code : {0}\nLibellé {1}\n\n", a.Key, a.Value.Libellé);
            }
            
        }
    }
}
