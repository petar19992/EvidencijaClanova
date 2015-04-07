using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EvidencijaClanova.Entiteti
{
    public class Clanarina
    {
        public virtual int clanarina_ID { get; protected set; }
        public virtual Clan clan { get; set; }
        public virtual DateTime pocetak { get; set; }
        public virtual DateTime kraj { get; set; }
        public virtual int clanarina { get; set; }
        public virtual bool placena { get; set; }
        public virtual int dug { get; set; }
    }
}
