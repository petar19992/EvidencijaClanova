using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EvidencijaClanova.Entiteti
{
    public class Trening
    {
        //public virtual int trening_ID { get; protected set; }
        public virtual String imeGrupe { get; set; }
        public virtual String termin { get; set; }
        public virtual IList<Clan> clanovi { get; set; }

        public Trening()
        {
            clanovi = new List<Clan>();
        }
        public virtual void dodajClana(Clan c)
        {
            c.trening = this;
            this.clanovi.Add(c);
        }
    }
}
