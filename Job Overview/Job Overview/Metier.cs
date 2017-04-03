using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Overview
{

    #region Enumeration
    /// <summary>
    /// Création d'un Type d'énuméré Flag afin de réaliser une association d'énumération pour les métiers (Concaténation Bit à Bit).
    /// </summary>
    [Flags]
    public enum Activités 
    {
        DRE,
        ARF,
        ANF,
        DES,
        INF,
        ART,
        ANT,
        DEV,
        RPT,
        TES,
        GDP

    }
    #endregion
    class Metier
    {


    }
}
