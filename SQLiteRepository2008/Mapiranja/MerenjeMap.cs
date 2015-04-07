using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FluentNHibernate.Mapping;
using EvidencijaClanova.Entiteti;

namespace EvidencijaClanova.Mapiranja
{
    public class MerenjeMap : ClassMap<Merenje>

    {
        public MerenjeMap()
        {
            Id(x => x.merenje_ID);

            Map(x => x.datumMerenja);
            Map(x => x.visina);
            Map(x => x.tezina);
            Map(x => x.brojGodina);
            Map(x => x.masti);
            Map(x => x.misici);
            Map(x => x.BMI);
            Map(x => x.visceralne);
            Map(x => x.obim);
            Map(x => x.brzinaMetabolizma);

            References(x => x.clan).ForeignKey("clanID");

        }

    }
}
