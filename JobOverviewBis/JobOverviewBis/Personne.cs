using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverviewBis
{
    public class Personne
    {
        #region Propriétés
        public string Code { get; }
        public string Nom { get;}
        public string Prénom { get;}
        public Metier Métier { get; }
        #endregion

        #region Constructeur
        public Personne(string code, string nom, string prénom, Metier métier)
        {
            Code = code;
            Nom = nom;
            Prénom = prénom;
            Métier = métier;
        }
        #endregion
    }
}
