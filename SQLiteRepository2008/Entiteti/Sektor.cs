using System;
using System.Collections.Generic;

namespace SQLiteRepository2008.Entiteti
{
    public class Sektor
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual IList<Radnik> Radnici { get; set; }
        public virtual IList<Projekat> Projekti { get; set; }

        public Sektor()
        {
            Radnici = new List<Radnik>();
            Projekti = new List<Projekat>();
        }

        public virtual void DodajRadnika(Radnik r)
        {
            r.Sektor = this;
            this.Radnici.Add(r);
        }

        public virtual void DodajProjekat(Projekat p)
        {
            p.Sektor = this;
            this.Projekti.Add(p);
        }
    }
}
