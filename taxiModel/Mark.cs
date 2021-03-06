﻿using System;
using System.Collections.Generic;

namespace taxiModel
{
    public partial class Mark
    {
        public Mark()
        {
            Transport = new HashSet<Transport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Transport> Transport { get; set; }
    }
}
