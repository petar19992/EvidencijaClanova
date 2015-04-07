using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EvidencijaClanova.Entiteti
{
    public class Merenje
    {
        public virtual int merenje_ID { get; protected set; }
        public virtual Clan clan { get; set; }
        public virtual DateTime datumMerenja { get; set; }
        public virtual float visina { get; set; }
        public virtual float tezina { get; set; }
        public virtual float brojGodina { get; set; }
        public virtual float masti { get; set; }
        public virtual float misici { get; set; }
        public virtual float BMI { get; set; }
        public virtual float visceralne { get; set; }
        public virtual float obim { get; set; }
        public virtual float brzinaMetabolizma { get; set; }

    }
}
