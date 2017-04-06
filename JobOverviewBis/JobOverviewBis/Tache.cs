using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverviewBis
{
    public class Tache
    {
        #region Propriétés
        public int NumTache { get; protected set; }
        public string Libellé { get; }
        public Personne AffectéA { get; }
        #endregion

        #region Constructeur
        public Tache(int numTache, string libellé, Personne affectéA)
        {
            NumTache = numTache;
            Libellé = libellé;
            AffectéA = affectéA;

        }
        #endregion
    }

    /// <summary>
    /// Tâches de production liées aux activités de production
    /// </summary>
    public class TâcheProduction: Tache
    {
        #region Propriétés
        public Version Version { get; }
        public ActivitésProd Activité { get; }
        public DateTime DateDébut { get; set; }
        public  int DuréePrévue { get; set; }
        public int DuréeRéalisée { get; set; }
        public int DuréeRestante { get; set; }
        #endregion

        #region Constructeur
        public TâcheProduction(int numTache, string libellé, Personne affectéA,
                ActivitésProd activités, Version version): base(numTache, libellé, affectéA)
        {
            Activité = activités;
            Version = version;
        }
        #endregion
    }

    public class TâcheAnnexe: Tache
    {
        #region Champs privés
        static int _numTâches = 0;
        #endregion
        #region Propriétés

        ActivitéAnnexe ActivitéAnnexe { get; }
        Dictionary<DateTime,int> DuréesMensuelles { get; }
        #endregion

        #region Constructeur
        public TâcheAnnexe(string libellé, Personne affectéA,
            ActivitéAnnexe activité): base(0, libellé, affectéA)
        {
            _numTâches++;
            ActivitéAnnexe = activité;
            DuréesMensuelles = new Dictionary<DateTime, int>();
        }
        #endregion
    }
}
