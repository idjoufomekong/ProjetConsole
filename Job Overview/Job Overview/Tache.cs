using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Overview
{
    public class Tache
    {

        #region Champs privés
        private int _codeTâche;
        private string _libelléTâche;
        private int _duréeTâche;
        private DateTime _dateDébut;
        private DateTime _dateFin;
        #endregion
        #region Propriétés
        public int CodeTâche { get; }
        public int LibelléTâche { get; }
        public int DuréeTâche { get; }
        public DateTime DateDébut { get { return _dateDébut; } }
        public DateTime DateFin { get { return _dateFin; } }
        #endregion
    }
}
