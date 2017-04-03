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
        public int CodeTâche { get { return _codeTâche; } }
        public string LibelléTâche { get { return _libelléTâche; } }
        public int DuréeTâche { get; }
        public DateTime DateDébut { get { return _dateDébut; } }
        public DateTime DateFin { get { return _dateFin; } }
        #endregion
        #region constructeur
        public Tache()
        {

        }
        public Tache(string libellé, int code)
        {
            _codeTâche = code;
            _libelléTâche = libellé;
        }
        #endregion
        #region Méthode public
        public string Affichage(int a, string b)
        {
            return string.Format("Code : {0}\nLibellé {1}\n\n", a, b);   
        }
        
      

        #endregion
    }

}
