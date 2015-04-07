using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using SQLiteRepository2008.Entiteti;


namespace SQLiteRepository2008.Mappings
{
    public class RadnikMapiranje : ClassMap<Radnik>
    {
        public RadnikMapiranje()
        {
            //mapiranje primarnog kljuca
            Id(x => x.Id);

            //mapiranje svojstava
            Map(x => x.Ime);
            Map(x => x.Prezime);
            Map(x => x.Plata);

            //mapiranje many-to-one veze
            References(x => x.Sektor);

            //mapiranje many-to-many veze
            HasManyToMany(x => x.Projekti)
                .Cascade.All()
                .Table("RadiNa");
        }
    }
}
