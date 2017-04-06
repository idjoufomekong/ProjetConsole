using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Overview
{
    /// <summary>
    /// 
    /// </summary>
    public class Version
    {/// <summary>
    /// La classe Version est une classe POCO qui stocke juste les différentes versions du logiciel. 
    /// Elle n'aura donc que des propriétés automatiques
    /// </summary>
        #region Champs privés
          
        #endregion

        #region propriétés
        public string Numéro { get; set; }
        public int Millésime { get; set; }
        public DateTime DateDébut { get; set; }
        public DateTime DatePubli { get; set; }

        #endregion

        #region Constructeurs
       
        #endregion

        #region Méthodes privées

        #endregion
        
        #region Méthodes publiques

        #endregion
    }
}
