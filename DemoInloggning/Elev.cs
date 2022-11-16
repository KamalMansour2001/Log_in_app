using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInloggning
{
    class Elev
    {
        public string Namn { get; set; }

        public int ID { get; set; }

        public int Lössenord { get; set; }

        public DateTime inlogning { get; set; }

        public DateTime Utlogning { get; set; }
        public bool Finns { get; set; }
        public Elev(string namn, int id , int lössen, DateTime inlog, DateTime utlog, bool finns) 
        {
            this.Namn = namn;
            this.ID = id;
            this.Lössenord = lössen;
            this.inlogning = inlog;
            this.Utlogning = utlog;
            this.Finns = finns;
        }
    }
}
