using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverviewBis
{
    #region Enumeration
    /// <summary>
    /// Création d'un Type d'énuméré Flag afin de réaliser une association d'énumération pour les métiers (Concaténation Bit à Bit).
    /// </summary>
    [Flags]
    public enum ActivitésProd
    {
        Aucun = 0,
        DBE = 1,
        ARF = 2,
        ANF = 4,
        DES = 8,
        INF = 16,
        ART = 32,
        ANT = 64,
        DEV = 128,
        RPT = 256,
        TES = 512,
        GDP = 1024
    }

    #endregion
    public class Metier
    {
        #region Propriétés
        public string Code { get;}
        public string Libellé { get; }
        public ActivitésProd Activités { get; }
        #endregion

        #region Constructeur
        public Metier(string code, string libellé, ActivitésProd activités)
        {
            Code = code;
            Libellé = libellé;
            Activités = activités;

        }
        #endregion
    }
}
