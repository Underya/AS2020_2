using System;
using System.Collections.Generic;

namespace taxiModel
{
    public partial class Phototransport
    {
        public Phototransport()
        {
            Transport = new HashSet<Transport>();
        }

        public int Id { get; set; }
        public char? Photo { get; set; }

        public virtual ICollection<Transport> Transport { get; set; }
    }
}
