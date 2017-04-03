using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Overview
{
      public  class TacheAnnexe
    {
        /// <summary>
        /// Cette classe gère les différentes tâches annexes qui seront rajoutées au fur et 
        /// à mesure par les employés
        /// </summary>
        #region Champs privés
        private string _nomTâche;
        private int _duréeTâche;
        private DateTime _dateDébut;
        private DateTime _dateFin;
               
        #endregion

        #region Propriétés
        public string NomTâche{get {return _nomTâche;}}
        public int DuréeTâche { get { return _duréeTâche; } }
        public DateTime DateDébut { get { return _dateDébut; } }
        public DateTime DateFin { get { return _dateFin; } }

        #endregion
        #region Constructeurs
        public TacheAnnexe(string nom, int durée, DateTime début, DateTime fin)
        {
            _nomTâche = nom ;
            _duréeTâche = durée;
            _dateDébut = début;
            _dateFin = fin;
        }

        #endregion
        #region Méthodes privées

        #endregion
        #region Méthodes publiques
        #endregion

    }
}
