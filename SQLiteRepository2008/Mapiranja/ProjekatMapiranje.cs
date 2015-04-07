using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using SQLiteRepository2008.Entiteti;

namespace SQLiteRepository2008.Mapiranja
{
    public class ProjekatMapiranje : ClassMap<Projekat>
    {
        ProjekatMapiranje()
        {
            //mapiranje primarnog kljuca
            Id(x => x.Id);

            //mapiranje svojstava
            Map(x => x.Naziv);
            
            //mapiranje many-to-one veze
            References(x => x.Sektor);

            //mapiranje many-to-many veze
            HasManyToMany(x => x.Radnici)
                .Cascade.All()
                .Table("RadiNa");
        }
    }
}
