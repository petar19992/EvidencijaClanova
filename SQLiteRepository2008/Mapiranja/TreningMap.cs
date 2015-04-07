using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FluentNHibernate.Mapping;
using EvidencijaClanova.Entiteti;

namespace EvidencijaClanova.Mapiranja
{
    public class TreningMap : ClassMap<Trening>
    {
        public TreningMap()
        {
            Id(x => x.imeGrupe);
            Map(x => x.termin);

            HasMany(x => x.clanovi).KeyColumn("imeGrupe")//Ovo proveri
            .Inverse()
            .Cascade.All();
        }
    }
}
