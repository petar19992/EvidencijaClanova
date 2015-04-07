using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FluentNHibernate.Mapping;
using EvidencijaClanova.Entiteti;

namespace EvidencijaClanova.Mapiranja
{
    public class ClanMap : ClassMap<Clan>
    {
        public ClanMap()
        {
            Id(x => x.clanID);
            Map(x => x.sifraKartice);
            Map(x => x.ime);
            Map(x => x.prezime);
            Map(x => x.datumRodjenja);
            Map(x => x.datumUpisa);
            Map(x => x.brojTelefona);
            Map(x => x.preporucenaIshrana);
            Map(x => x.clanarina);
            Map(x => x.placena);
            Map(x => x.dug);
            Map(x => x.napomena);

            References(c => c.trening).ForeignKey("imeGrupe");

            HasMany(x => x.sveClanarine).KeyColumn("Clan_id") //Ovo proveri
            .Inverse()
            .Cascade.All();

            HasMany(x => x.svaMerenja).KeyColumn("Clan_id") //I ovo
            .Inverse()
            .Cascade.All();
        }
    }
}
