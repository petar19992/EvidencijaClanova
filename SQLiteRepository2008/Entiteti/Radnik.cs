using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLiteRepository2008.Entiteti
{
    public class Radnik
    {
            public virtual int Id { get; protected set; }
            public virtual string Ime { get; set; }
            public virtual string Prezime { get; set; }
            public virtual double Plata { get; set; }
            public virtual Sektor Sektor { get; set; }
            public virtual IList<Projekat> Projekti { get; set; }

            public Radnik()
            {
                Projekti = new List<Projekat>();
            }
        
    }
}
