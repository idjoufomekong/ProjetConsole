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
            Console.WriteLine("Saisi des activités annexes\n");
            int nombre = 1; // declaration et initialisation de nombre

            SortedList<int, string> EntréeTaches = new SortedList<int, string>();

            while (nombre != 0)

            {
                bool codeUnique;
                int b;
                string a;
                Console.WriteLine("Veuillez saisir le code de la tache a ajouter :");
                try
                {
                    string test;
                    b = int.Parse(Console.ReadLine());
                    //pour le code b y a t-il un string deja existant dans EntréeTaches ?
                    codeUnique = EntréeTaches.TryGetValue(b, out test);
                    while (codeUnique == true)
                    {
                        Console.WriteLine("Erreur : Chaque code d'activité doit être unique");
                        Console.WriteLine("Veuillez saisir le code de la tache a ajouter :");
                        b = int.Parse(Console.ReadLine());
                        codeUnique = EntréeTaches.TryGetValue(b, out test);
                    }


                    Console.WriteLine("Veuillez saisir le libellé de la tache a ajouter :");
                    a = Console.ReadLine();
                    // Console.WriteLine("Le libellé correspondant au code {0} est : {1}\n", b, a);
                    Tache n = new Tache(a, b);
                    EntréeTaches.Add(b, a);
                    Console.WriteLine("Veuillez entrer une valeur différente à 0.\nPour sortir, entrez 0.\n");
                    nombre = int.Parse(Console.ReadLine());
                    Console.WriteLine("");

                }
                catch (FormatException)
                {
                    Console.WriteLine("Erreur : Veuillez entrer un chiffre");
                }

            }

            Console.Clear();
            //affichage des activités annexes saisies
            Console.WriteLine("Liste des activités annexes saisies classées selon leur code :\n");
            foreach (var a in EntréeTaches)
            {
                Console.WriteLine("Code : {0}\nLibellé {1}\n\n", a.Key, a.Value);
            }
            
        }
    }
}
