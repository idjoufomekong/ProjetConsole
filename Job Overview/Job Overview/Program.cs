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
            /// <summary>
            /// creation d'une boucle afin de rentrer la liste des taches par l'utilisateur. 
            /// l'utilisateur doit rentrer le chiffre 0 s'il a terminé d'entrer ses activités annexes
            /// </summary>

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

            Dal données = new Job_Overview.Dal();
            données.ChargerDonnées();

            Console.ReadKey();
        }
    
            
                
            
            
        


    }
}