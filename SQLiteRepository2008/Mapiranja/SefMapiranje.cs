using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SQLiteRepository2008.Entiteti;

namespace SQLiteRepository2008.Mapiranja
{
    public class SefMapiranje: SubclassMap<Sef>
    {
        public SefMapiranje()
        {
            Map(x => x.DatumPostavljenja);
        }
    }
}
