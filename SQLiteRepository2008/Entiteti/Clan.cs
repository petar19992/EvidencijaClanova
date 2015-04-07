using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EvidencijaClanova.Entiteti
{
    public class Clan
    {
        public virtual int clanID { get; protected set; } //Ovo sam dodao, neka ovo bude ID
        public virtual int sifraKartice { get;  set; } //promenio sam da vise nije protected (7.4)
        public virtual String ime { get; set; }
        public virtual String prezime { get; set; }
        public virtual DateTime datumRodjenja { get; set; }
        public virtual DateTime datumUpisa { get; set; }
        public virtual String brojTelefona { get; set; }
        public virtual String preporucenaIshrana { get; set; }
        public virtual int clanarina { get; set; }
        public virtual bool placena { get; set; }
        public virtual int dug { get; set; }
        public virtual String napomena { get; set; }
        public virtual Trening trening { get; set; }
        public virtual IList<Clanarina> sveClanarine { get; set; }
        public virtual IList<Merenje> svaMerenja { get; set; }
        public Clan()
        {
            sveClanarine = new List<Clanarina>();
            svaMerenja = new List<Merenje>();
        }
        public virtual void dodajClanarinu(Clanarina c)
        {
            c.clan = this;
            this.sveClanarine.Add(c);
        }
        public virtual void dodajMerenje(Merenje m)
        {
            m.clan = this;
            this.svaMerenja.Add(m);
        }
    }
}
