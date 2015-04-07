using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SQLiteRepository2008.Entiteti
{
    public class Projekat
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual Sektor Sektor { get; set; }
        public virtual IList<Radnik> Radnici { get; set; }

        public Projekat()
        {
            Radnici = new List<Radnik>();
        }
    }
}
