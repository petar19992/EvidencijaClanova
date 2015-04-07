using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLiteRepository2008.Entiteti
{
    public class Sef : Radnik
    {
        public virtual DateTime DatumPostavljenja { get; set; }
    }
}
