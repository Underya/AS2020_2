using System;
using System.Collections.Generic;

namespace taxiModel
{
    public partial class Roles
    {
        public Roles()
        {
            Rf = new HashSet<Rf>();
            Ur = new HashSet<Ur>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Systemname { get; set; }

        public virtual ICollection<Rf> Rf { get; set; }
        public virtual ICollection<Ur> Ur { get; set; }
    }
}
