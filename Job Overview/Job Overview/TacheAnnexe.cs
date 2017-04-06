using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Overview
{
    public class TacheAnnexe : Tache
    {
        /// <summary>
        /// Cette classe gère les différentes tâches annexes qui seront rajoutées au fur et 
        /// à mesure par les employés
        /// </summary>
        #region Champs privés
        private static List<TacheAnnexe> _tacheAnnexe = new List<TacheAnnexe>();
        //KDprivate int _duréeTâche; 
        #endregion

        #region Propriétés
        public string CodeEmployé { get; set; }
        public static List<TacheAnnexe> TacheA { get { return _tacheAnnexe; } }
        // public int DuréeTâche { get { return _duréeTâche; } }
        #endregion
        #region Constructeurs
        public TacheAnnexe(string nom, int code) : base(nom, code)
        {

        }
        public TacheAnnexe(string nom, int code, int durée) : base(nom, code, durée)
        {

        }
        public TacheAnnexe(string libellé, int code, int durée, DateTime dateDebut) : base(libellé, code, durée, dateDebut)
        {

        }
        #endregion
        #region Méthodes privées

        #endregion
        #region Méthodes publiques
        //calcul du temps passé par un employé sur les activités annexe
        public string CumulTacheAEmployé(string code)
        {

            int cumul = 0;
            foreach (var a in TacheA)
            {
                if (code.CompareTo(a.CodeEmployé) == 0)
                {
                    cumul += a._duréeTâche;
                }
            }
            return string.Format("Le cumul de temps passé sur les activités annexes réalisés par l'employé {0} est de {1} j", code, cumul);

        }

        //Calcul du cumul de temps passé sur un activité
        public string CumulTaches(string taches)
        {

            int cumul = 0;
            foreach (var a in TacheA)
            {
                if (taches.CompareTo(a._libelléTâche) == 0)
                {
                    cumul += a._duréeTâche;
                }
            }
            return string.Format("Le cumul de temps passé sur l'activité annexe {0} est de {1} j", taches, cumul);

        }

        //Cumul de temps passé sur une activité en un mois
        public string CumulTachesMois(string taches)
        {

            string s = string.Empty;

            List<TacheAnnexe> tacheMois = new List<TacheAnnexe>();
            var Mois = TacheA.Select(c => c._dateDébut).Distinct();
            int cumul = 0;
            foreach (var a in Mois)
            {
                var tache = TacheA.Where(c => c._dateDébut == a);
                foreach (var b in tache)
                {
                    if (taches.CompareTo(b._libelléTâche) == 0)
                    {
                        cumul += b._duréeTâche;
                    }
                }
                s += string.Format("\nLe cumul de temps passé sur l'activité annexe {0} est de {1} j durant le mois de {2}", taches, cumul, a.ToString("MMMM"));
            }
            return s;

        }
        #endregion

    }
}
