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
                    Console.WriteLine("Veuillez rentrer 0 si vous ne souhaitez pas rentrer de nouvelles tache sinon, veuillez entrer une valeur différente à 0");
                    nombre = int.Parse(Console.ReadLine());
                    Console.WriteLine("");

                }
                catch (FormatException)
                {
                    Console.WriteLine("Erreur : Veuillez entrer un chiffre");
                }




            }

            Console.Clear();

            foreach (var a in EntréeTaches)
            {
                Console.WriteLine("Code : {0}\nLibellé {1}\n\n", a.Key, a.Value);
            }

            //Chargement du fichier de données
            Dal données = new Job_Overview.Dal();
            données.ChargerDonnées();

            //Affichage du logiciel et des versions
            string s = string.Empty;
            List<string> versions = données.Versions();
            foreach (var a in versions)
            {
                s += a + ", ";
            }
            Console.WriteLine("Le logiciel {0} compte {1} versions qui sont: {2}",
                données.Logiciel, versions.Count(), s);


            //Affichage de la liste des métiers et activités associées
            List<string> métiers = données.MétiersEtActivités();
            Console.WriteLine("La liste des métiers est la suivante");

            foreach (var a in métiers)
            {
                Console.WriteLine(a.ToString());
            }

            //Affichade de la liste de personnes avec leur métier
            List<string> personnes = données.PersonnesEtMétier();
            Console.WriteLine("\nLa liste des personnes avec leur métier est la suivante");

            foreach (var a in personnes)
            {
                Console.WriteLine(a.ToString());
            }

            //Affichade de la liste des tâches
            List<string> tâches = données.ListeTâches();
            Console.WriteLine("\nLa liste des tâches est la suivante");

            foreach (var a in tâches)
            {
                Console.WriteLine(a.ToString());
            }


            Console.WriteLine("Veuillez saisir l'initial du prenom de la personne souhaité puis le nom afin d'obtenir la durée du travail réalisé sur une version");
            string initial = Console.ReadLine();
            Result x = new Result();

            int réalisé1, restante1, réalisé2, restante2; // création de variables int por recevoir la durée total du travail réalisé et restante
            x.CalculDureeTravailRealise(initial, out réalisé1, out restante1, out réalisé2, out restante2); //On recupère les durées grâce au out
            Console.WriteLine("Durée réalisée par {0} sur la version 1.00 : {1}\nDurée restante : {2}\nDurée réalisée par {0} sur la version 2.00 : {3}\nDurée restante : {4}", initial, réalisé1, restante1, réalisé2, restante2);

            Result ret = new Result();
            int retard;
            ret.CalculNombreJour(out retard);
            Console.WriteLine("Nombre de jours d'avance ou de retard : {0}", retard);



           Console.ReadKey();
        }








    }
}