using System;
using System.Collections.Generic;

namespace taxiModel
{
    public partial class Ur
    {
        public int Id { get; set; }
        public int Idusers { get; set; }
        public int Idroles { get; set; }

        public virtual Roles IdrolesNavigation { get; set; }
        public virtual Users IdusersNavigation { get; set; }

        public void Load()
        {
        }
    }
}
