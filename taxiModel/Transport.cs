using System;
using System.Collections.Generic;

namespace taxiModel
{
    public partial class Transport
    {
        public Transport()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Model { get; set; }
        public DateTime? Datecreate { get; set; }
        public string Nunber { get; set; }
        public DateTime? Dateregistration { get; set; }
        public string Datewriteoff { get; set; }
        public int Idmark { get; set; }
        public int? Idphoto { get; set; }
        public int Idstatus { get; set; }

        public virtual Mark IdmarkNavigation { get; set; }
        public virtual Phototransport IdphotoNavigation { get; set; }
        public virtual Statustransport IdstatusNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
