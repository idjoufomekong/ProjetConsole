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


            List<Employé> employés = new List<Employé>();

            Employé e1 = new Employé("GL", "Geneviève", "LECLERCQ", "ANA");
            employés.Add(e1);
            Employé e2 = new Employé("GL", "Geneviève", "LECLERCQ", "ANA");
            employés.Add(e2);
            Employé e3 = new Employé("GL", "Geneviève", "LECLERCQ", "CDP");
            employés.Add(e3);
            Employé e4 = new Employé("GL", "Geneviève", "LECLERCQ", "DEV");
            employés.Add(e4);
            Employé e5 = new Employé("GL", "Geneviève", "LECLERCQ", "DES");
            employés.Add(e5);
            Employé e6 = new Employé("GL", "Geneviève", "LECLERCQ", "DEV");
            employés.Add(e6);
            Employé e7 = new Employé("GL", "Geneviève", "LECLERCQ", "DES");
            employés.Add(e7);
            Employé e8 = new Employé("GL", "Geneviève", "LECLERCQ", "TES");
            employés.Add(e6);
            Employé e9 = new Employé("GL", "Geneviève", "LECLERCQ", "TES");
            employés.Add(e7);

            List<Version> versions1 = new List<Version>();
            Version v1 = new Version
            {
                Numéro = "1.00",
                Millésime = 2017,
                DateDébut = new DateTime(02, 01, 16),
                DatePubli = new DateTime(08, 01, 17),
            };
            versions1.Add(v1);
            Version v2 = new Version
            {
                Numéro = "2.00",
                Millésime = 2018,
                DateDébut = new DateTime(28, 12, 16),
                DatePubli = new DateTime()
            };
            versions1.Add(v2);


            //Création de taches de production
            List<TacheProduction> listeprod = new List<TacheProduction>();
            TacheProduction t1 = new TacheProduction(54, "Tache 1")
            {
                DureePrevue = 60,
                DureeRealise = 21,
                DureeRestante = 39,           
                CodeEmployé = "GL"
            };
            listeprod.Add(t1);

            TacheProduction t2 = new TacheProduction(74, "Tache 2")
            {
                DureePrevue = 70,
                DureeRealise = 31,
                DureeRestante = 39,
                CodeEmployé = "GL"
            };
            listeprod.Add(t2);

            TacheProduction t3 = new TacheProduction(42, "Tache 3")
            {
                DureePrevue = 80,
                DureeRealise = 21,
                DureeRestante = 59,
                CodeEmployé = "GL"
            };
            listeprod.Add(t3);
            //appel changement de la durée restante à 10 jours
            Console.WriteLine("Après modification, {0}",t3.ModificationDureeRestante(10));

            Console.ReadKey();
            Console.Clear();


            //création de taches annexes
            TacheAnnexe tA1 = new TacheAnnexe("Tache 1", 31, 45, new DateTime(2017,2,12))
            {
                CodeEmployé = "GL",
                
                
            };
            TacheAnnexe.TacheA.Add(tA1);

            TacheAnnexe tA2 = new TacheAnnexe("Tache 2", 74, 87, DateTime.Today)
            {
                CodeEmployé = "GL"
                
            };
            TacheAnnexe.TacheA.Add(tA2);
            DateTime date1 = new DateTime(2017,11,05);
            TacheAnnexe tA3 = new TacheAnnexe("Tache 3", 82, 55, date1)
            {
                CodeEmployé = "HK"
            };
            TacheAnnexe.TacheA.Add(tA3);

            TacheAnnexe tA4 = new TacheAnnexe("Tache 3", 87, 12, new DateTime(2017, 5, 10))
            {
                CodeEmployé = "NP"
            };
            TacheAnnexe.TacheA.Add(tA4);

            //on affiche le cumul de la durée consacrée a réaliser une tache annexe
            Console.WriteLine(tA1.CumulTacheAEmployé("GL"));
            Console.WriteLine(tA1.CumulTaches("Tache 3"));
            Console.WriteLine(tA1.CumulTachesMois("Tache 3"));

            Console.ReadKey();
            Console.Clear();


            //Suivi de la classe DAL
            Console.WriteLine("Gestion de la classe DAL\n");
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
            Console.ReadKey();
            Console.Clear();

            //Affichage de la liste des métiers et activités associées
            List<string> métiers = données.MétiersEtActivités();
            Console.WriteLine("La liste des métiers est la suivante :\n");

            foreach (var a in métiers)
            {
                Console.WriteLine(a.ToString());
            }

            Console.ReadKey();
            Console.Clear();

            //Affichade de la liste de personnes avec leur métier
            List<string> personnes = données.PersonnesEtMétier();
            Console.WriteLine("La liste des personnes avec leur métier est la suivante :\n");

            foreach (var a in personnes)
            {
                Console.WriteLine(a.ToString());
            }

            Console.ReadKey();
            Console.Clear();

            //Affichade de la liste des tâches
            List<string> tâches = données.ListeTâches();
            Console.WriteLine("La liste des tâches est la suivante :\n");

            foreach (var a in tâches)
            {
                Console.WriteLine(a.ToString());
            }

            Console.ReadKey();
            Console.Clear();



            //Saisie de la liste des activités annexes
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
            Console.ReadKey();
            Console.Clear();






            //Suivie de la production
            Console.WriteLine("Suivi de la production\n");



            //Permet d'afficher les durées du travail restant et réalisé par une personne en rentrant son initial
            Console.WriteLine("Veuillez saisir le code de la personne afin d'obtenir sa durée de travail réalisé sur une version");
            string initial = Console.ReadLine();
            Result x = new Result();

            int réalisé1, restante1, réalisé2, restante2; // création de variables int por recevoir la durée total du travail réalisé et restante
            x.CalculDureeTravailRealise(initial, out réalisé1, out restante1, out réalisé2, out restante2); //On recupère les durées grâce au out
            Console.WriteLine("Durée réalisée par {0} sur la version 1.00 : {1}\nDurée restante : {2}\nDurée réalisée par {0} sur la version 2.00 : {3}\nDurée restante : {4}", initial, réalisé1, restante1, réalisé2, restante2);

            Console.ReadKey();
            Console.Clear();

            //Permet l'affichage des jours de retard ou d'avance sur une version
            Console.WriteLine("État d'avancement des Versions :\n");
            Result ret = new Result();
            int retard1, retard2, pourcentage1, pourcentage2;
            double pourcentage1Retard, pourcentage2Retard;
            ret.CalculNombreJour(out retard1, out retard2, out pourcentage1, out pourcentage2, out pourcentage1Retard, out pourcentage2Retard);
            if (retard1 < 0)
            {
                
                Console.WriteLine("Nombre de jours de retard sur la version 1.00 : {0} j\n Il y a donc {1}% de retard", Math.Abs(retard1), pourcentage1Retard);
            }
            else Console.WriteLine("Nombre de jours d'avance sur la version 1.00 : {0} j\n Il y a donc {1}% d'avancement", retard1, pourcentage1);

            if (retard2 < 0)
            {

                Console.WriteLine("Nombre de jours de retard sur la version 2.00 : {0} j\n Il y a donc {1}% de retard", Math.Abs(retard2), pourcentage2Retard);
            }
            else Console.WriteLine("Nombre de jours d'avance sur la version 2.00 : {0} j\n Il y a donc {1}% d'avancement", retard2, pourcentage2);

            Console.ReadKey();
            Console.Clear();



            // Affichage de la liste de la durée totale de travail par activités pour la version 1
            Result listeb = new Result();
            Console.WriteLine("\nAffichade de la liste de la durée totale de travail par activités pour la version 1.00");
            Console.WriteLine(listeb.CalculDureeTotal1());

            // Affichage de la liste de la durée totale de travail par activités pour la version 2
            Console.WriteLine("\nAffichade de la liste de la durée totale de travail par activités pour la version 2.00");
            Console.WriteLine(listeb.CalculDureeTotal2());

            Console.ReadKey();
            Console.Clear();
        }








    }
}