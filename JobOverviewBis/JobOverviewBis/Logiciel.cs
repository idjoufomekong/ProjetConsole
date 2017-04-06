using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverviewBis
{
    /// <summary>
    /// Création de la classe Logiciel, chaque logiciel dispose de plusieurs versions
    /// </summary>
    public class Logiciel
    {
        #region Propriétés
        public string Nom { get; }
        public string Description { get; set; }
        public Dictionary<string, Version> Versions { get; set; }

        #endregion
        public Logiciel(string nom)
        {
            Nom = nom;
            Versions = new Dictionary<string, Version>();
        }
    }

    /// <summary>
    /// Création de la classe version 
    /// </summary>
    public class Version
    {
        #region Propriétés
        public string NumVersion { get;}
        public int Millésime { get;}
        public DateTime DateDébut { get;}
        public DateTime? DatePubli { get; set; }
        #endregion

        #region Constructeur
        public Version(string numVersion, int millésime, DateTime dateDébut, DateTime? datePubli)
        {
            NumVersion = numVersion;
            Millésime = millésime;
            DateDébut = dateDébut;
            DatePubli = datePubli;
        }
        #endregion
    }
}
