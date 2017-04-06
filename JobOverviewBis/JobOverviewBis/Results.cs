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
    }
}
