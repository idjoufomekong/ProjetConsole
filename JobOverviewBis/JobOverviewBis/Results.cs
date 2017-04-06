using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverviewBis
{
    public class Results
    {
        private DAL _data;

        public Results(string fichier)
        {
            _data = new DAL(fichier);
            
        }

        // Durées de travail réalisée et restante d’une personne sur une version
        public void DuréesTravail(string version, string pers, out int réalisé, out int restant)
        {
            var taches = _data.Tâches.OfType<TâcheProduction>().
                Where(T => T.Version.NumVersion == version &&
                T.AffectéA.Code == pers);

            réalisé = taches.Sum(T => T.DuréeRéalisée);
            restant = taches.Sum(T => T.DuréeRestante);
        }

        // Nombre de jours et pourcentage d’avance ou de retard sur une version
        public void BilanVersion(string version, out int diff, out int pourcentDif)
        {
            var taches = _data.Tâches.OfType<TâcheProduction>().
                Where(T => T.Version.NumVersion == version);

            int réalisé = taches.Sum(T => T.DuréeRéalisée);
            int prévu = taches.Sum(T => T.DuréePrévue);

            diff = réalisé - prévu;
            pourcentDif = diff / prévu * 100;
        }

        // Durées totales de travail réalisées sur la production d’une version, pour chaque activité
        public Dictionary<ActivitésProd, int> TravailRéaliséParActivité(string version)
        {
            var res = new Dictionary<ActivitésProd, int>();
            var activités = _data.Tâches.OfType<TâcheProduction>().Select(T => T.Activité).Distinct();

            foreach (var a in activités)
            {
                int durée = _data.Tâches.OfType<TâcheProduction>().
                    Where(T => T.Version.NumVersion == version &&
                    T.Activité == a).Sum(T => T.DuréeRéalisée);

                res.Add(a, durée);
            }

            return res;
        }
    }
}
