using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using SQLiteRepository2008.Entiteti;

namespace SQLiteRepository2008.Mapiranja
{
    public class SektorMapiranje : ClassMap<Sektor>
    {
        SektorMapiranje()
        {
            //mapiranje primarnog kljuca
            Id(x => x.Id);

            //mapiranje svojstava
            Map(x => x.Naziv);
            
            //mapiranje one-to-many veza
            HasMany(x => x.Radnici)
                .Inverse()
                .Cascade.All();

            HasMany(x => x.Projekti)
                .Inverse()
                .Cascade.All();
        }
    }
}
