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
            var personnes = Data.Select(c => c.Personne).Distinct(); //Liste de tâches par personne
            List<string> liste1 = new List<string>();
            List<string, List<string>> liste2 = new List<string, List<string>>();
            foreach ( var a in personnes)
            {

                var activités = Data.Where(c => c.Personne == a).Distinct().Select(c => c.Activité);
                //liste.Add(activités);
                activités.ToList();
            }
            return liste1;
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

