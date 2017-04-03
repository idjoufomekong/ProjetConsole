using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Job_Overview
{
    public class Dal
    {
        #region Champs privés
        private List<DonnéesTâcheProd> _data = new List<DonnéesTâcheProd>();
        const string _LOGICIEL = "Data Manager";
        private List<Metier> _listeMétiers = new List<Metier>();
        private List<Employé> _listeEmployés = new List<Employé>();
        private List<Tache> _listetaches = new List<Tache>();
        private List<Version> _listeVersions = new List<Version>();
        #endregion
        #region Propriétés
        public List<DonnéesTâcheProd> Data
        {
            get { return _data; }
        }
        public string Logiciel
        {
            get { return _LOGICIEL; }
        }
        #endregion

        #region Constructeurs

        #endregion

        #region Méthodes privées

        #endregion

        #region Méthodes publiques
        public void ChargerDonnées()
        {
            string chemin = @"..\..\Data.txt";

            int cpt = 0;
            using (StreamReader str = new StreamReader(chemin))
            {
                string ligne;

                while ((ligne = str.ReadLine()) != null)
                {
                    cpt++;
                    if (cpt == 1) continue; // On n'analyse pas la première ligne car elle contient les en-têtes

                    var tab = ligne.Split('\t');
                    try
                    {
                        var DonnéesTâcheProd = new DonnéesTâcheProd
                        {
                            NumTache = int.Parse(tab[0]),
                            Version = tab[1],
                            Personne = tab[2],
                            Activité = tab[3],
                            LibTache = tab[4],
                            DateDébut = DateTime.Parse(tab[5]),
                            DuréePrévue = int.Parse(tab[6]),
                            DuréeRéalisée = int.Parse(tab[7]),
                            DuréeRestante = int.Parse(tab[8])
                        };

                        // Ajout de la tâche affectée à la liste
                        Data.Add(DonnéesTâcheProd);
                    }
                    catch (FormatException)
                    {
                        // On ignore simplement la ligne
                        Console.WriteLine("Erreur de format à la ligne suivante :\r\n{0}", ligne);
                    }
                }
            }
        }
        /// <summary>
        /// Liste de versions du logiciel
        /// </summary>
        /// <returns></returns>
        public List<string> Versions()
        {
            //DonnéesTâcheProd données = new DonnéesTâcheProd();
            
            var b = Data.Select(c => c.Version).Distinct();
            int nbreVersion = b.Count();
            List<string> s = new List<string>();

            foreach(var a in b)
            {
                s.Add(a);
            }
            return s;
        }

        /// <summary>
        /// Liste des métiers et activités associées
        /// </summary>

        public List<string> MétiersEtActivités()
        {
            Metier m = new Metier();
            string p;
            string s = string.Empty;


            List<string> listeMétiers = new List<string>();
            List<string> listeMétiers1 = new List<string>();
            var personnes = Data.Select(c => c.Personne).Distinct(); //Liste unique de personnes
            //var activités = Data.Select(c => c.Activité).Distinct();
            List<string> liste1 = new List<string>();
           // List<string, List<string>> liste2 = new List<string, List<string>>();
            foreach ( var a in personnes)
            {
                Activités l;
                var activités = Data.Where(c => c.Personne == a).Select(c => c.Activité).Distinct();
                liste1 = activités.ToList();
                l = Activités.Aucun;
                //l = l | (Activités) Enum.Parse(typeof(Activités), liste1.First());
                foreach (var b in liste1)
                {
                    l = l | (Activités)Enum.Parse(typeof(Activités), b);
                    
                }
                p = m.RetournerMétier(l);
                //if (p.Contains("")) continue;
                listeMétiers.Add(p);
                
                
            }
            var listemétiersuniques = listeMétiers;
            //foreach (var a in listeMétiers) listemétiersuniques.Add(a);
           //listeMétiers.Clear();
            foreach(var c in listeMétiers)
            {
                if ((c.CompareTo("")) == 0) continue;
                s = c  + ": " + m.RetournerActivités(c);
                listeMétiers1.Add(string.Format(s));
            }
            

            return listeMétiers1;
        }
        /// <summary>
        /// Liste de personnes avec leur métier
        /// </summary>
        public List<string> PersonnesEtMétier()
        {
            Metier m = new Metier();
            string p;
            string s = string.Empty;
            List<string> listeMétiers = new List<string>();
            Dictionary<string,string> dico = new Dictionary<string,string>();
            var personnes = Data.Select(c => c.Personne).Distinct(); //Liste unique de personnes
            
            List<string> liste1 = new List<string>();
           
            foreach (var a in personnes)
            {
                Activités l;
                var activités = Data.Where(c => c.Personne == a).Select(c => c.Activité).Distinct();
                liste1 = activités.ToList();
                l = Activités.Aucun;
                
                foreach (var b in liste1)
                {
                    l = l | (Activités)Enum.Parse(typeof(Activités), b);

                }
                p = m.RetournerMétier(l);
                dico.Add(a, p);
                
            }
            
            
            foreach (var c in dico)
            {
                s = string.Format("L'employé {0} a pour métier {1}", c.Key, c.Value);
                listeMétiers.Add(s);
            }
            return listeMétiers;

        }

        public List<string> ListeTâches()
        {
            List<string> liste = new List<string>();
            string s,p;
            int j;
            var liste1 = Data.Select(c => c.LibTache).Distinct();
            foreach(var a in liste1)
            {
                s = a.ToString();
                int i = s.IndexOf('-');
                //s = s.Substring(i + 1);
                s = s.Substring(i + 2);
                //char[] tab = s.ToCharArray();
                //for(int z = tab.Length-2; z>0; z--)
                //{
                //    if(tab[z].CompareTo(' ') == 0)
                        
                //}
                liste.Add(s);
            }
            return liste;
        }

        #endregion
    }
        
    /// <summary>
    /// Classe contenant les données d'une tâche de production du logiciel affectée à une personne
    /// </summary>

    public class DonnéesTâcheProd
    {
        public int NumTache { get; set; }
        public string Version { get; set; }
        public string Personne { get; set; }
        public string Activité { get; set; }
        public string LibTache { get; set; }
        public  DateTime DateDébut { get; set; }
        public int DuréePrévue { get; set; }
        public int DuréeRéalisée { get; set; }
        public int DuréeRestante { get; set; }

    }
}

