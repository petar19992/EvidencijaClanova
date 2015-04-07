using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FluentNHibernate.Mapping;
using EvidencijaClanova.Entiteti;

namespace EvidencijaClanova.Mapiranja
{
    public class ClanarinaMap : ClassMap<Clanarina>
    {
        public ClanarinaMap()
        {
            Id(x => x.clanarina_ID);

            Map(x => x.pocetak);
            Map(x => x.kraj);
            Map(x => x.clanarina);
            Map(x => x.placena);
            Map(x => x.dug);

            References(x => x.clan).ForeignKey("clanID");
        }
    }
}
