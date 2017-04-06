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

            //Affichage de quelques résultats de suivi de production
            Console.WriteLine();
            Console.WriteLine("Réultats du suivi de production");
            try
            {
                var res = new Results(@"..\..\Data.txt");

                int réalisé, restant;
                string pers = "GL";
                res.DuréesTravail("2.00", pers, out réalisé, out restant);

                Console.WriteLine("Sur la version {0}, {1} a fait {2}j, et il lui en reste {3}",
                    2018, pers, réalisé, restant);

                var travail = res.TravailRéaliséParActivité("1.00");
                Console.WriteLine();
                Console.WriteLine("Travail réalisé sur la version 1.00 par activité :");
                foreach (var kvp in travail)
                    Console.WriteLine(" - {0} : {1}j", kvp.Key, kvp.Value);

            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Fichier de données Data.txt introuvable");
            }

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
