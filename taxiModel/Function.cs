using System;
using System.Collections.Generic;

namespace taxiModel
{
    public partial class Function
    {
        public Function()
        {
            Rf = new HashSet<Rf>();
        }

        public int Id { get; set; }
        public string Systemname { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Rf> Rf { get; set; }
    }
}
