using System;
using System.Collections.Generic;

namespace taxiModel
{
    public partial class Rf
    {
        public int Id { get; set; }
        public int Idfunction { get; set; }
        public int Idroles { get; set; }

        public virtual Function IdfunctionNavigation { get; set; }
        public virtual Roles IdrolesNavigation { get; set; }
    }
}
